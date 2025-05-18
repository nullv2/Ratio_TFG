using Ratio.Mobile.Enums;
using Ratio.Mobile.Models;
using Ratio.Mobile.Models.Chat;
using Ratio.Mobile.Models.Chat.OpenAI;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Ratio.Mobile.Services
{
    public class OpenAIChatService
    {
        private readonly HttpClient _client;
        private readonly OpenAIConfig _openAIConfig;
        private string _threadId;

        public OpenAIChatService(OpenAIConfig openAIConfig)
        {
            _openAIConfig = openAIConfig;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAIConfig.ApiKey);
            _client.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
        }

        /// <summary>
        /// Initializes a new chat thread and stores its ID for future interactions.
        /// </summary>
        public async Task InitializeThreadAsync()
        {
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://api.openai.com/v1/threads", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var threadResponse = JsonSerializer.Deserialize<ThreadResponse>(responseContent);
            _threadId = threadResponse.id;
        }

        /// <summary>
        /// Sends a message to the existing thread and returns the assistant's reply.
        /// </summary>
        public async Task<string> SendMessageAsync(ChatHistory history)
        {
            //Get last user message
            var userMessage = history.Messages.LastOrDefault(m => m.Role == ChatRole.User)?.Content;

            if (string.IsNullOrEmpty(_threadId))
                await InitializeThreadAsync();

            await AddMessageToThreadAsync(_threadId, userMessage);
            await RunThreadAsync(_threadId);
            await Task.Delay(5000); // Replace with proper polling if needed

            // Fetch messages and extract assistant's reply
            var assistantReply = await GetLatestAssistantMessageAsync(_threadId);

            return assistantReply;
        }
        private async Task<string> GetLatestAssistantMessageAsync(string threadId)
        {
            var response = await _client.GetAsync($"https://api.openai.com/v1/threads/{threadId}/messages");
            var responseContent = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseContent);
            var root = doc.RootElement;

            // Navigate to the latest assistant message content
            var messages = root.GetProperty("data");
            var latestMessage = messages.EnumerateArray().FirstOrDefault();

            var textContent = latestMessage
                .GetProperty("content")[0]
                .GetProperty("text")
                .GetProperty("value")
                .GetString();

            return textContent ?? "[No assistant response found]";
        }


        private async Task AddMessageToThreadAsync(string threadId, string messageContent)
        {
            var messageRequest = new MessageRequest { content = messageContent };
            var json = JsonSerializer.Serialize(messageRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync($"https://api.openai.com/v1/threads/{threadId}/messages", content);
        }

        private async Task RunThreadAsync(string threadId)
        {
            var runRequest = new RunRequest
            {
                assistant_id = _openAIConfig.AssistantId,
                instructions = _openAIConfig.Prompt
            };
            var json = JsonSerializer.Serialize(runRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync($"https://api.openai.com/v1/threads/{threadId}/runs", content);
        }

        private async Task<string> GetThreadMessagesAsync(string threadId)
        {
            var response = await _client.GetAsync($"https://api.openai.com/v1/threads/{threadId}/messages");
            return await response.Content.ReadAsStringAsync();
        }
    }

}

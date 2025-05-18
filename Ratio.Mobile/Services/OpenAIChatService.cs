using Ratio.Mobile.Models.Chat;
using System.Net.Http.Json;

using OpenAI;
using OpenAI.Assistants;


namespace Ratio.Mobile.Services
{
    public class OpenAIChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _model;

        public OpenAIChatService(string apiKey, string model = "gpt-3.5-turbo")
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
            _model = model;
        }

        public async Task<string> SendMessageAsync(ChatHistory history)
        {
            // Inject system prompt first
            var messages = new List<object>
    {
        new
        {
            role = "system",
            content = "You are Ratio Tactical, an expert tactical advisor for Warhammer 40,000: Kill Team, providing insights based on the latest 2025 rules and balance dataslates. You respond with actionable, clear tactical advice."
        }
    };

            // Add the rest of the history
            messages.AddRange(history.Messages.Select(m => new { role = m.Role.ToString().ToLower(), content = m.Content }));

            var request = new
            {
                model = _model,
                messages = messages
            };

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
            {
                Content = JsonContent.Create(request)
            };
            httpRequest.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            return result?.Choices?.FirstOrDefault()?.Message?.Content?.Trim();
        }


        private class OpenAIResponse
        {
            public List<Choice> Choices { get; set; }

            public class Choice
            {
                public ChatMessageDto Message { get; set; }
            }

            public class ChatMessageDto
            {
                public string Role { get; set; }
                public string Content { get; set; }
            }
        }


    }
}

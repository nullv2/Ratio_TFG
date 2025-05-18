using Ratio.Mobile.Models.Chat;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Ratio.Mobile.Services
{
    public class OllamaChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _model;

        public OllamaChatService(string model = "llama3")
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://10.0.2.2:11434") };
            _model = model;
        }

        public async Task<string> SendMessageAsync(ChatHistory history)
        {
            var request = new
            {
                model = _model,
                messages = history.Messages.Select(m => new { role = m.Role.ToString().ToLower(), content = m.Content }),
                stream = false
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/chat", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();
            return result?.Message?.Content?.Trim();
        }

        private class OllamaResponse
        {
            public ChatMessageDto Message { get; set; }

            public class ChatMessageDto
            {
                public string Role { get; set; }
                public string Content { get; set; }
            }
        }
    }
}

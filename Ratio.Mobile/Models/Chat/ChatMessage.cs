using Ratio.Mobile.Enums;

namespace Ratio.Mobile.Models.Chat
{
    public class ChatMessage
    {
        public ChatRole Role { get; set; }  // "user" or "assistant"
        public string Content { get; set; }

        public ChatMessage(ChatRole role, string content)
        {
            Role = role;
            Content = content;
        }
    }
}
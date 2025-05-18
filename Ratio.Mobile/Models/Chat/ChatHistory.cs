using Ratio.Mobile.Enums;

namespace Ratio.Mobile.Models.Chat
{
    public class ChatHistory
    {
        public List<ChatMessage> Messages { get; } = new();

        public void AddUserMessage(string content) => Messages.Add(new ChatMessage(ChatRole.User, content));
        public void AddAssistantMessage(string content) => Messages.Add(new ChatMessage(ChatRole.Assistant, content));
    }
}

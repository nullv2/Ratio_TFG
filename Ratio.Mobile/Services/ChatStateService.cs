using Ratio.Mobile.Models.Chat;

namespace Ratio.Mobile.Services
{
    public class ChatStateService
    {
        public ChatHistory ChatHistory { get; private set; } = new();

        public void ClearHistory()
        {
            ChatHistory = new ChatHistory();
        }
    }

}

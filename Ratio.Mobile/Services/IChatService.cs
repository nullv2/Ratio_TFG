using Ratio.Mobile.Models.Chat;

namespace Ratio.Mobile.Services
{
    interface IChatService
    {
        Task<string> SendMessageAsync(ChatHistory history);
    }
}
namespace Ratio.Mobile.Models.Chat.OpenAI
{
    public class ThreadResponse
    {
        public string id { get; set; }
        public long created_at { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}

using ElGuayaBot.Domain.Business.Updates.Common;

namespace ElGuayaBot.Domain.Business.Updates.ChatTitleChanged
{
    public class ChatTitleChangedUpdateRequest : IUpdateRequest
    {
        public int Id { get; set; }
        public UpdateType Type { get; set; }
        public long ChatId { get; set; }
        public string NewChatTitle { get; set; }
    }
}
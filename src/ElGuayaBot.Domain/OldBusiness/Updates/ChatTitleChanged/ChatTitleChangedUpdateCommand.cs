using ElGuayabot.Domain.Business.Updates.Common;

namespace ElGuayabot.Domain.Business.Updates.ChatTitleChanged
{
    public class ChatTitleChangedUpdateCommand : UpdateCommand
    {
        public int Id { get; set; }
        public UpdateType Type { get; set; }
        public long ChatId { get; set; }
        public string NewChatTitle { get; set; }
    }
}
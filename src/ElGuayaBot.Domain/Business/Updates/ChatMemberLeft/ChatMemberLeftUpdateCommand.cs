using ElGuayabot.Domain.Business.Updates.Common;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Domain.Business.Updates.ChatMemberLeft
{
    public class ChatMemberLeftUpdateCommand: UpdateCommand
    {
        public int Id { get; set; }
        public UpdateType Type { get; set; }
        public long ChatId { get; set; }
        public User LeftChatMember { get; set; }
    }
}
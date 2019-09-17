using ElGuayabot.Domain.Business.Updates.Common;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Domain.Business.Updates.ChatMembersAdded
{
    public class ChatMembersAddedUpdateCommand : UpdateCommand
    {
        public int Id { get; set; }
        public UpdateType Type { get; set; }
        public long ChatId { get; set; }
        public User[] NewChatMembers { get; set; }
    }
}
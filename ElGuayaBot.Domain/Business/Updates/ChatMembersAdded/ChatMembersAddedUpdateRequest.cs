using ElGuayaBot.Domain.Business.Updates.Common;
using ElGuayaBot.Domain.Entity;

namespace ElGuayaBot.Domain.Business.Updates.ChatMembersAdded
{
    public class ChatMembersAddedUpdateRequest : IUpdateRequest
    {
        public int Id { get; set; }
        public UpdateType Type { get; set; }
        public long ChatId { get; set; }
        public User[] NewChatMembers { get; set; }
    }
}
using ElGuayaBot.Domain.Entity;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotification : INotification
    {
        public int Id { get; set; }
        public UpdateType Type { get; set; }
        public long ChatId { get; set; }
        public User[] NewChatMembers { get; set; }
        public User LeftChatMember { get; set; }
        public string NewChatTitle { get; set; }
    }

    public enum UpdateType
    {
        Other,
        ChatTitleChanged,
        ChatMemberLeft,
        ChatMembersAdded
    }
}
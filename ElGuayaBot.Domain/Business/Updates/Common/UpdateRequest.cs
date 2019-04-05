using ElGuayaBot.Domain.Entity;

namespace ElGuayaBot.Domain.Business.Updates.Common
{
    public class UpdateRequest : IUpdateRequest
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
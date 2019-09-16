using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;

namespace ElGuayabot.Domain.Business.Updates.Common
{
    public abstract class UpdateCommand: Request<Result>
    {
        int Id { get; set; }
        UpdateType Type { get; set; }
        long ChatId { get; set; }
    }
    
    public enum UpdateType
    {
        Other,
        ChatTitleChanged,
        ChatMemberLeft,
        ChatMembersAdded
    }
}
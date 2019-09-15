using ElGuayaBot.Common.Request;
using ElGuayaBot.Common.Result;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates.Common
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
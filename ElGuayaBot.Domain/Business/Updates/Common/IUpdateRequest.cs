using ElGuayaBot.Common.Result;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates.Common
{
    public interface IUpdateRequest : IRequest<Result>
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
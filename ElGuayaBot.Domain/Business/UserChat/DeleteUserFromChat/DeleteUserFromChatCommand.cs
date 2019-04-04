using ElGuayaBot.Common.Request;
using ElGuayaBot.Common.Result;

namespace ElGuayaBot.Domain.Business.UserChat.DeleteUserFromChat
{
    public class DeleteUserFromChatCommand : Request<Result>
    {
        public int UserId { get; set; }
        public long ChatId { get; set; }
    }
}
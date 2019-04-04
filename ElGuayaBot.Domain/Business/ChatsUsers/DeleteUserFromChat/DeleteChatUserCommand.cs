using ElGuayaBot.Common.Request;
using ElGuayaBot.Common.Result;

namespace ElGuayaBot.Domain.Business.ChatsUsers.DeleteUserFromChat
{
    public class DeleteChatUserCommand : Request<Result>
    {
        public int UserId { get; set; }
        public long ChatId { get; set; }
    }
}
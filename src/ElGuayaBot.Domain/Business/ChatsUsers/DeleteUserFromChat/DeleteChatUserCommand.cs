using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Domain.Business.ChatsUsers.DeleteUserFromChat
{
    public class DeleteChatUserCommand : Request<Result>
    {
        public int UserId { get; set; }
        public long ChatId { get; set; }
    }
}
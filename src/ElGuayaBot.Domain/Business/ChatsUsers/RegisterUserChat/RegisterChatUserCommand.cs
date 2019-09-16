using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Domain.Business.ChatsUsers.RegisterUserChat
{
    public class RegisterChatUserCommand : Request<Result>
    {
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}
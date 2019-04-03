using ElGuayaBot.Common.Request;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Entity;

namespace ElGuayaBot.Domain.Business.UserChat.RegisterUserChat
{
    public class RegisterUserChatCommand : Request<Result>
    {
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}
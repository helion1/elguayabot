using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Domain.Business.Chats.ChangeChatTitle
{
    public class ChangeChatTitleCommand : Request<Result>
    {
        public long ChatId { get; set; }
        public string NewChatTitle { get; set; }
    }
}
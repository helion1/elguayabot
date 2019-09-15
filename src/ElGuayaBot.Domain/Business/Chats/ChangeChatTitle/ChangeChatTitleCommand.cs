using ElGuayaBot.Common.Request;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Entity;

namespace ElGuayaBot.Domain.Business.Chats.ChangeChatTitle
{
    public class ChangeChatTitleCommand : Request<Result>
    {
        public long ChatId { get; set; }
        public string NewChatTitle { get; set; }
    }
}
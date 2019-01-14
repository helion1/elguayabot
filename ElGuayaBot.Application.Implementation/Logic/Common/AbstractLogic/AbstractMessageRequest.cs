using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic
{
    public class AbstractMessageRequest : AbstractRequest
    {
        public Message Message { get; set; }
    }
}
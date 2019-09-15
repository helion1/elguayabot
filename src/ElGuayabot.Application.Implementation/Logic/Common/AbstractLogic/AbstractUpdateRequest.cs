using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic
{
    public class AbstractUpdateRequest : AbstractRequest
    {
        public Update Update { get; set; }
    }
}
using Telegram.Bot.Types;

namespace ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic
{
    public class AbstractUpdateRequest : AbstractRequest
    {
        public Update Update { get; set; }
    }
}
using MediatR;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic
{
    public abstract class AbstractRequest: IRequest<Unit>
    {
        public Message Message { get; set; }
    }
}
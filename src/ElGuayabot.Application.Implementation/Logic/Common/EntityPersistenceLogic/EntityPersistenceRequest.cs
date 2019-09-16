using MediatR;
using Telegram.Bot.Types;

namespace ElGuayabot.Application.Implementation.Logic.Common.EntityPersistenceLogic
{
    public class EntityPersistenceRequest : IRequest<Unit>
    {
        public Message Message { get; set; }
    }
}
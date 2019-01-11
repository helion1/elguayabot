using MediatR;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Logic.EntityPersistenceLogic
{
    public class EntityPersistenceLogicRequest : IRequest<Unit>
    {
        public Message Message { get; set; }
    }
}
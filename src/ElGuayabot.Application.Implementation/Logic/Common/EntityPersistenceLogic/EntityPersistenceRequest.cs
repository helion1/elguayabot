using MediatR;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Logic.Common.EntityPersistenceLogic
{
    public class EntityPersistenceRequest : IRequest<Unit>
    {
        public Message Message { get; set; }
    }
}
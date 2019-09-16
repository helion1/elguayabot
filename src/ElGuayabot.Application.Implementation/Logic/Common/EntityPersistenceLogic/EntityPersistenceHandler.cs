using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace ElGuayabot.Application.Implementation.Logic.Common.EntityPersistenceLogic
{
    public class EntityPersistenceHandler : IRequestHandler<EntityPersistenceRequest>
    {
        private readonly IChatService _chatService;
        
        private readonly IUserService _userService;
        
        private readonly IChatUserService _chatUserService;

        private readonly ILogger<EntityPersistenceHandler> _logger;

        public EntityPersistenceHandler(IChatService chatService, IUserService userService, IChatUserService chatUserService, ILogger<EntityPersistenceHandler> logger)
        {
            _chatService = chatService;
            _userService = userService;
            _chatUserService = chatUserService;
            _logger = logger;
        }

        public async Task<Unit> Handle(EntityPersistenceRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            await PersistChat(message);
            
            await PersistUser(message);
            
            await PersistChatUserRelationship(message);
            
            return Unit.Value;
        }

        private async Task PersistChat(Message message)
        {
            if (!_chatService.IsPersisted(message.Chat.Id))
            {
                await _chatService.AddAsync(message.Chat.Id, message.Chat.Type, message.Chat.Title);
            }
        }

        private async Task PersistUser(Message message)
        {
            if (!_userService.IsPersisted(message.From.Id))
            {
                await _userService.AddAsync(message.From.Id, message.From.Username, message.From.IsBot, message.From.LanguageCode);
            }
        }

        private async Task PersistChatUserRelationship(Message message)
        {
            if (!_chatUserService.IsPersisted(message.Chat.Id, message.From.Id))
            {
                await _chatUserService.AddAsync(message.Chat.Id, message.From.Id);
            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.OnUpdate.IsNewChatTitleLogic
{
    public class IsNewChatTitleHandler : AbstractHandler<IsNewChatTitleRequest>
    {
        private readonly IChatService _chatService;

        
        public IsNewChatTitleHandler(IBotClient bot, ILogger<AbstractHandler<IsNewChatTitleRequest>> logger, IChatService chatService) : base(bot, logger)
        {
            _chatService = chatService;
        }

        public override async Task<Unit> Handle(IsNewChatTitleRequest request, CancellationToken cancellationToken)
        {
            var update = request.Update;
            
            var message = update.Message;

            await _chatService.UpdateTitleForChat(message.Chat.Id, message.NewChatTitle);
            
            return Unit.Value;
        }
    }
}
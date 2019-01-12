using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.CommandMessageLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.MiscellaneousMessageLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.UrlMessageLogic;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.OnMessageDispatcherLogic
{
    public class OnMessageDispatcherHandler : AbstractHandler<OnMessageDispatcherRequest>
    {
        private readonly IMediator _mediatR;

        public OnMessageDispatcherHandler(IBotClient bot, ILogger<AbstractHandler<OnMessageDispatcherRequest>> logger, IMediator mediatR) : base(bot, logger)
        {
            _mediatR = mediatR;
        }

        public override async Task<Unit> Handle(OnMessageDispatcherRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            if (message == null || message.Type != MessageType.Text)
            {
                return Unit.Value;
            }

            MessageEntity firstEntity = null;
            if (message.Entities?.Length == 0)
            {
                firstEntity = message.Entities.First();
            }
            
            if (firstEntity?.Type == MessageEntityType.BotCommand)
            {
                await _mediatR.Send(new CommandMessageRequest { Message = message}, cancellationToken);
            }
            else if (message.Entities != null && message.Entities.Any( m => m.Type == MessageEntityType.Url))
            {
                await _mediatR.Send(new UrlMessageRequest { Message = message}, cancellationToken);
            }
            else if (message.Text.Trim() != "")
            {
                await _mediatR.Send(new MiscellaneousMessageRequest {Message = message}, cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}
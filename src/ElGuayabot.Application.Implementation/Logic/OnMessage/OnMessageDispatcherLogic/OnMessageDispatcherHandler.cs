using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.IsCommandDispatcherLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.IsMiscellaneousDispatcherLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.IsUrlDispatcherLogic;
using MediatR;
using Microsoft.Extensions.Logging;
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
            
            if (message.Entities != null && message.Entities.Length != 0)
            {
                firstEntity = message.Entities.First();
            }
            
            if (firstEntity?.Type == MessageEntityType.BotCommand)
            {
                await _mediatR.Send(new IsCommandDispatcherRequest { Message = message}, cancellationToken);
            }
            else if (message.Entities != null && message.Entities.Any( m => m.Type == MessageEntityType.Url))
            {
                await _mediatR.Send(new IsUrlDispatcherRequest { Message = message}, cancellationToken);
            }
            else if (message.Text.Trim() != "")
            {
                await _mediatR.Send(new IsMiscellaneousDispatcherRequest {Message = message}, cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}
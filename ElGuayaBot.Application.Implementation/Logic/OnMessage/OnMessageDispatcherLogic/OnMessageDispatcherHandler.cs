using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.CommandMessageLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.OnMessageDispatcherLogic
{
    public class OnMessageDispatcherHandler : AbstractHandler<OnMessageDispatcherRequest>
    {
        private readonly IMediator _mediatR;

        public OnMessageDispatcherHandler(IBotClient bot, ILogger<OnMessageDispatcherHandler> logger, IMediator mediatR) : base(bot, logger)
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

            var firstEntity = message.Entities.FirstOrDefault();
            
            if (firstEntity != null && firstEntity.Type == MessageEntityType.BotCommand)
            {
                await _mediatR.Send(new CommandMessageRequest { Message = message}, cancellationToken);
                
            }
            else if (message.Entities.Any( m => m.Type == MessageEntityType.Url))
            {
                //URL
                //                if (message.Text.ToLower().Contains(".gif") && message.Text.ToLower().StartsWith("https://"))
//                {
//                    _tenorGifFlow.Initiate(message);
//                }
            }
            else
            {            

//                else
//                {
//                    if(message.Text.ToLower().Contains("puto guayaba"))
//                    {
//                        _putoGuayaba.Initiate(message);
//                    }
//                    else
//                    {
//                        _randomTextFlow.Initiate(message);
//                    }
//
//                }
            }            
            return Unit.Value;
        }
    }
}
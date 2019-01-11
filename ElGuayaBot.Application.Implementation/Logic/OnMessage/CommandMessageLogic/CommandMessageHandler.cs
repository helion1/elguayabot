using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Command.PingPongLogic;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.CommandMessageLogic
{
    public class CommandMessageHandler: AbstractHandler<CommandMessageRequest>
    {
        private readonly IMediator _mediatR;

        public CommandMessageHandler(IBotClient bot, ILogger<CommandMessageHandler> logger, IMediator mediatR) : base(bot, logger)
        {
            _mediatR = mediatR;
        }

        public override async Task<Unit> Handle(CommandMessageRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);
            
            var command = message.EntityValues.FirstOrDefault();

            var restOfText = message.Text.Substring(message.Text.IndexOf(' ') + 1);

            switch (command)
            {
//                case "/about":
//                    _aboutFlow.Initiate(message);
//                    break;
//                case "/help":
//                    _aboutFlow.Initiate(message);
//                    break;
                case "/ping":
                    await _mediatR.Send(new PingPongRequest { Message = message });
                    break;
//                case "/flip":
//                    _flipCoinFlow.Initiate(message);
//                    break;
//                case "/comandante":
//                    _comandanteFlow.Initiate(message);
//                    break;
//                case "/fruta":
//                    _frutaFlow.Initiate(message);
//                    break;
//                case "/dab":
//                    _dabFlow.Initiate(message);
//                    break;
//                case "/comunica":
//                    message.Text = restOfText;
//                    _comunicaTest.Initiate(message);
//                    break;
//                default:
//                    _unknownFlow.Initiate(message);
//                    break;
            }
            
            return Unit.Value;
        }
    }
}
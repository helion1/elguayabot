using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Command.AboutLogic;
using ElGuayaBot.Application.Implementation.Logic.Command.ComandanteLogic;
using ElGuayaBot.Application.Implementation.Logic.Command.ComunicaLogic;
using ElGuayaBot.Application.Implementation.Logic.Command.DabLogic;
using ElGuayaBot.Application.Implementation.Logic.Command.FlipLogic;
using ElGuayaBot.Application.Implementation.Logic.Command.GuayabaLogic;
using ElGuayaBot.Application.Implementation.Logic.Command.HelpLogic;
using ElGuayaBot.Application.Implementation.Logic.Command.OtherLogic;
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

        public CommandMessageHandler(IBotClient bot, ILogger<AbstractHandler<CommandMessageRequest>> logger, IMediator mediatR) : base(bot, logger)
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
                case "/about":
                    await _mediatR.Send(new AboutRequest { Message = message });
                    break;
                case "/comandante":
                    await _mediatR.Send(new ComandanteRequest { Message = message });
                    break;
                case "/comunica":
                    await _mediatR.Send(new ComunicaRequest { Message = message });
                    break;
                case "/dab":
                    await _mediatR.Send(new DabRequest { Message = message });
                    break;
                case "/flip":
                    await _mediatR.Send(new FlipRequest { Message = message });
                    break;
                case "/fruta":
                case "/guayaba":
                    await _mediatR.Send(new GuayabaRequest { Message = message });
                    break;
                case "/help":
                    await _mediatR.Send(new HelpRequest { Message = message });
                    break;
                case "/ping":
                    await _mediatR.Send(new PingPongRequest { Message = message });
                    break;

                default:
                    await _mediatR.Send(new OtherRequest { Message = message });
                    break;
            }
            
            return Unit.Value;
        }
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Implementation.Logic.Command.AboutLogic;
using ElGuayabot.Application.Implementation.Logic.Command.ComandanteLogic;
using ElGuayabot.Application.Implementation.Logic.Command.ComepingasLogic;
using ElGuayabot.Application.Implementation.Logic.Command.ComunicaLogic;
using ElGuayabot.Application.Implementation.Logic.Command.DabLogic;
using ElGuayabot.Application.Implementation.Logic.Command.EchoLogic;
using ElGuayabot.Application.Implementation.Logic.Command.FlipLogic;
using ElGuayabot.Application.Implementation.Logic.Command.GuayabaLogic;
using ElGuayabot.Application.Implementation.Logic.Command.HelpLogic;
using ElGuayabot.Application.Implementation.Logic.Command.OtherLogic;
using ElGuayabot.Application.Implementation.Logic.Command.PingPongLogic;
using ElGuayabot.Application.Implementation.Logic.Command.SavageLogic;
using ElGuayabot.Application.Implementation.Logic.Command.StatsLogic;
using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Logic.OnMessage.IsCommandDispatcherLogic
{
    public class IsCommandDispatcherHandler: AbstractHandler<IsCommandDispatcherRequest>
    {
        private readonly IMediator _mediatR;

        public IsCommandDispatcherHandler(IBotClient bot, ILogger<AbstractHandler<IsCommandDispatcherRequest>> logger, IMediator mediatR) : base(bot, logger)
        {
            _mediatR = mediatR;
        }

        public override async Task<Unit> Handle(IsCommandDispatcherRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);
            
            var command = message.EntityValues.First();

            if (command.Contains('@'))
            {
                command = command.Substring(0, command.IndexOf('@'));
            }
            
            switch (command)
            {
                case "/about":
                    await _mediatR.Send(new AboutRequest { Message = message });
                    break;
                case "/comandante":
                    await _mediatR.Send(new ComandanteRequest { Message = message });
                    break;
                case "/comepingas":
                    await _mediatR.Send(new ComepingasRequest { Message = message });
                    break;
                case "/comunica":
                    await _mediatR.Send(new ComunicaRequest { Message = message });
                    break;
                case "/dab":
                    await _mediatR.Send(new DabRequest { Message = message });
                    break;
                case "/echo":
                    await _mediatR.Send(new EchoRequest { Message = message });
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
                case "/savage":
                    await _mediatR.Send(new SavageRequest { Message = message });
                    break;    
                case "/stats":
                    await _mediatR.Send(new StatsRequest { Message = message });
                    break;

                default:
                    await _mediatR.Send(new OtherRequest { Message = message });
                    break;
            }
            
            return Unit.Value;
        }
    }
}
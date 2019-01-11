using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.DispatcherLogic
{
    public class DispatcherHandler : AbstractHandler<DispatcherRequest>
    {
        private readonly IMediator _mediatR;

        public DispatcherHandler(BlockingTelegramBotClient bot, ILogger<DispatcherHandler> logger, IMediator mediatR) : base(bot, logger)
        {
            _mediatR = mediatR;
        }

        public override async Task<Unit> Handle(DispatcherRequest request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
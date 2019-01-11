using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.MiscellaneousMessageLogic
{
    public class MiscellaneousMessageHandler : AbstractHandler<MiscellaneousMessageRequest>
    {
        public MiscellaneousMessageHandler(IBotClient bot, ILogger<MiscellaneousMessageHandler> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(MiscellaneousMessageRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
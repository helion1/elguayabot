using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.FlipLogic
{
    public class FlipHandler : AbstractHandler<FlipRequest>
    {
        public FlipHandler(IBotClient bot, ILogger<AbstractHandler<FlipRequest>> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(FlipRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
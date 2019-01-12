using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.DabLogic
{
    public class DabHandler : AbstractHandler<DabRequest>
    {
        public DabHandler(IBotClient bot, ILogger<AbstractHandler<DabRequest>> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(DabRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
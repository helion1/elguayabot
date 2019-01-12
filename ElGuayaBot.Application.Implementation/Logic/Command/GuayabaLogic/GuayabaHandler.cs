using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.GuayabaLogic
{
    public class GuayabaHandler : AbstractHandler<GuayabaRequest>
    {
        public GuayabaHandler(IBotClient bot, ILogger<AbstractHandler<GuayabaRequest>> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(GuayabaRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
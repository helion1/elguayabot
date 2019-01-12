using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.OtherLogic
{
    public class OtherHandler : AbstractHandler<OtherRequest>
    {
        public OtherHandler(IBotClient bot, ILogger<AbstractHandler<OtherRequest>> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(OtherRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
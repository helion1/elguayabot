using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.HelpLogic
{
    public class HelpHandler : AbstractHandler<HelpRequest>
    {
        public HelpHandler(IBotClient bot, ILogger<AbstractHandler<HelpRequest>> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(HelpRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
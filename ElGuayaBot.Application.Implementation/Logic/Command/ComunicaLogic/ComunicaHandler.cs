using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.ComunicaLogic
{
    public class ComunicaHandler : AbstractHandler<ComunicaRequest>
    {
        public ComunicaHandler(IBotClient bot, ILogger<AbstractHandler<ComunicaRequest>> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(ComunicaRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
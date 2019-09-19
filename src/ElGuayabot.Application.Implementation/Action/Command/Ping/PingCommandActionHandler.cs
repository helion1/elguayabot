using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Command.Ping
{
    public class PingCommandActionHandler : CommonHandler<PingCommandAction, Result>
    {
        public PingCommandActionHandler(ILogger<CommonHandler<PingCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(PingCommandAction request, CancellationToken cancellationToken)
        {
            var difference = request.Timestamp - request.MessageSentDateTime;

            var insults = new[]
            {
                "muerdealmohadas",
                "comepingas",
                "jalabolas",
                "pendejo",
                "mamaguebo",
                "becerro"
            };
            
            var rnd = new Random();

            var n = rnd.Next(insults.Length);

            var luckyInsult = insults[n];
            
            var text =$"_pong!_ He tardado `{difference.TotalSeconds:N2}` milisegundos en recibir _tu_ mensaje. Los mismos que duras tu en la cama, *{luckyInsult}*";

            return await MediatR.Send(new TextResponse(text), cancellationToken);
        }
    }
}
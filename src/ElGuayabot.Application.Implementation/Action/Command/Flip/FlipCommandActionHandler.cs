using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Command.Flip
{
    public class FlipCommandActionHandler : CommonHandler<FlipCommandAction, Result>
    {
        public FlipCommandActionHandler(ILogger<CommonHandler<FlipCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(FlipCommandAction request, CancellationToken cancellationToken)
        {
            var rnd = new Random();

            var coin = rnd.Next(2);

            var toss = coin == 1 ? "cara" : "cruz";

            var text = $"<i>No soy monedita de oro pa' caerle bien a todos</i>, pero la moneda ha caido en <b>{toss}</b>.";
            
            return await MediatR.Send(new TextResponse(text, ParseMode.Html), cancellationToken);
        }
    }
}
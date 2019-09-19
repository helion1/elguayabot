using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.CallateLaJeta
{
    public class CallateLaJetaMiscellaneousActionHandler : CommonHandler<CallateLaJetaMiscellaneousAction, Result>
    {
        public CallateLaJetaMiscellaneousActionHandler(ILogger<CommonHandler<CallateLaJetaMiscellaneousAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(CallateLaJetaMiscellaneousAction request, CancellationToken cancellationToken)
        {
            var responses = new[]
            {
                "CÁLLATE LA JETA MALDITO SAPO",
                "NO GRITES JODER",
                "VERGA CALLATE YA"
            };

            var rnd = new Random();
            
            var r = rnd.Next(responses.Length);
            
            var response = $"<b>{responses[r]}</b>";

            return await MediatR.Send(new TextResponse(response, ParseMode.Html), cancellationToken);
        }
    }
}
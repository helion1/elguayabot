using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.NoEstesTriste
{
    public class NoEstesTristeMiscellaneousActionHandler : CommonHandler<NoEstesTristeMiscellaneousAction, Result>
    {
        public NoEstesTristeMiscellaneousActionHandler(ILogger<CommonHandler<NoEstesTristeMiscellaneousAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(NoEstesTristeMiscellaneousAction request, CancellationToken cancellationToken)
        {
            var responses = new[]
            {
                "<i>Mi</i> vida ya es lo suficientemente miserable como para que <i>tu</i> estes triste",
                "Al menos <i>tu</i> puedes comprar papel de vater",
                "¿Tu agua <i>también</i> tiene malaria?",
                "Al menos no compras <i>GigaByte</i>",
                "Te lo aseguro, el suicido no va a cambiar las cosas",
                "No te preocupes, el comandante se encarga",
                "Levanta el animo, <i>El Guayaba</i> te quiere",
            };
            
            var rnd = new Random();
            
            var r = rnd.Next(responses.Length + 1);
            
            var response = $"{responses[r]}";
            
            return await MediatR.Send(new TextResponse(response, ParseMode.Html), cancellationToken);
        }
    }
}
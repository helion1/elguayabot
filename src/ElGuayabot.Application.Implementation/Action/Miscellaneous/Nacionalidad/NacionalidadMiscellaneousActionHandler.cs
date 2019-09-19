using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.Nacionalidad
{
    public class NacionalidadMiscellaneousActionHandler : CommonHandler<NacionalidadMiscellaneousAction, Result>
    {
        public NacionalidadMiscellaneousActionHandler(ILogger<CommonHandler<NacionalidadMiscellaneousAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(NacionalidadMiscellaneousAction request, CancellationToken cancellationToken)
        {
            var responses = new[]
            {
                "La primera gestoría no valió de nada",
                "Cuando pedi el de la segunda me llego el de la primera",
                "Fuí victima de racismo",
                "Soy español, queridos compadres",
                "llegué el 19 de mayo y me lo dieron hace una semana",
                "Tan solo he necesitado 5 meses y 3 días para obtener la nacionalidad",
                "en teoría si es por primera vez y tienes todos los recaudos tardas un solo día"
            };
            
            var rnd = new Random();
            
            var r = rnd.Next(responses.Length);
            
            var response = $"{responses[r]}";

            return await MediatR.Send(new TextResponse(response), cancellationToken);
        }
    }
}
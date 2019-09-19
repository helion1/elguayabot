using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Command.Help
{
    public class HelpCommandActionHandler : CommonHandler<HelpCommandAction, Result>
    {
        public HelpCommandActionHandler(ILogger<CommonHandler<HelpCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(HelpCommandAction request, CancellationToken cancellationToken)
        {
            var helpText = "Hasta cuándo, nos preguntamos desde Venezuela señor Presidente, señoras, señores, hasta cuándo vamos a permitir tales injusticias y desigualdades; hasta cuándo vamos a tolerar el actual orden económico internacional y los mecanismos de mercado vigente; hasta cuándo vamos a permitir que grandes epidemias como el VIH SIDA arrasen con poblaciones enteras; hasta cuándo vamos a permitir que los hambrientos no puedan alimentarse, ni alimentar a sus propios hijos; hasta cuándo vamos a permitir que sigan muriendo millones de niños por enfermedades curables; hasta cuándo vamos a permitir conflictos armados que masacran a millones de seres humanos inocentes, con el fin de apropiarse los poderosos de los recursos de otros pueblos. Cesen las agresiones y las guerras pedimos los pueblos del mundo a los imperios, a los que pretenden seguir dominando el mundo y explotándonos.\n <i>El comando de ayuda esta aun sin desarrollar, compañero!</i>";

            return await MediatR.Send(new TextResponse(helpText), cancellationToken);
        }
    }
}
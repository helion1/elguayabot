using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Command.HelpLogic
{
    public class HelpHandler : AbstractHandler<HelpRequest>
    {
        public HelpHandler(IBotClient bot, ILogger<AbstractHandler<HelpRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(HelpRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            var helpText = "Hasta cuándo, nos preguntamos desde Venezuela señor Presidente, señoras, señores, hasta cuándo vamos a permitir tales injusticias y desigualdades; hasta cuándo vamos a tolerar el actual orden económico internacional y los mecanismos de mercado vigente; hasta cuándo vamos a permitir que grandes epidemias como el VIH SIDA arrasen con poblaciones enteras; hasta cuándo vamos a permitir que los hambrientos no puedan alimentarse, ni alimentar a sus propios hijos; hasta cuándo vamos a permitir que sigan muriendo millones de niños por enfermedades curables; hasta cuándo vamos a permitir conflictos armados que masacran a millones de seres humanos inocentes, con el fin de apropiarse los poderosos de los recursos de otros pueblos. Cesen las agresiones y las guerras pedimos los pueblos del mundo a los imperios, a los que pretenden seguir dominando el mundo y explotándonos.\n <i>El comando de ayuda esta aun sin desarrollar, compañero!</i>";
                
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: helpText,
                parseMode: ParseMode.Html, 
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}
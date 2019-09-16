using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Logic.Miscellaneous.NacionalidadLogic
{
    public class NacionalidadHandler : AbstractHandler<NacionalidadRequest>
    {
        public NacionalidadHandler(IBotClient bot, ILogger<AbstractHandler<NacionalidadRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(NacionalidadRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var responses = new List<string>
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
            
            var r = rnd.Next(responses.Count);
            
            var response = $"{responses[r]}";
                
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: response,
                    replyToMessageId: message.MessageId,
                    cancellationToken: cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}
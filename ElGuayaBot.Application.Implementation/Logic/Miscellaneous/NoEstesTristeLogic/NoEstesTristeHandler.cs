using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Miscellaneous.NoEstesTristeLogic
{
    public class NoEstesTristeHandler : AbstractHandler<NoEstesTristeRequest>
    {
        public NoEstesTristeHandler(IBotClient bot, ILogger<AbstractHandler<NoEstesTristeRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(NoEstesTristeRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var responses = new List<string>
            {
                "<i>Mi</i> vida ya es lo suficientemente miserable como para que <i>tu</i> estes triste",
                "Al menos <i>tu</i> puedes comprar papel de vater",
                "¿Tu agua <i>también</i> tiene malaria?",
                "Al menos no compras <i>GigaByte</i>"
            };
            
            var rnd = new Random();
            
            var r = rnd.Next(responses.Count);
            
            var response = $"{responses[r]}";

            if (r % 2 == 0)
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
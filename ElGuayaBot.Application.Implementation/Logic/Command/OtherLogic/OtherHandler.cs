using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.OtherLogic
{
    public class OtherHandler : AbstractHandler<OtherRequest>
    {
        public OtherHandler(IBotClient bot, ILogger<AbstractHandler<OtherRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(OtherRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var responses = new List<string>
            {
                "No te entiendo maldito lázaro",
                "Sacate el huevo de la boca"
            };
            
            //TODO: refactor this random mess
            var rnd = new Random();

            var r = rnd.Next(responses.Count);

            var r2 = rnd.Next(10);
            
            if (r2 == 1)
            {
                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: responses[r],
                    replyToMessageId: message.MessageId,
                    cancellationToken: cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}
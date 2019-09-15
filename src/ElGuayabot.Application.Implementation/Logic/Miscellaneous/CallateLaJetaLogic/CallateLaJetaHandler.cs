using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Miscellaneous.CallateLaJetaLogic
{
    public class CallateLaJetaHandler : AbstractHandler<CallateLaJetaRequest>
    {
        public CallateLaJetaHandler(IBotClient bot, ILogger<AbstractHandler<CallateLaJetaRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(CallateLaJetaRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var responses = new List<string>
            {
                "CÁLLATE LA JETA MALDITO SAPO",
                "NO GRITES JODER",
                "VERGA CALLATE YA"
            };

            var rnd = new Random();
            
            var r = rnd.Next(responses.Count);
            
            var response = $"<b>{responses[r]}</b>";
            
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: response,
                    parseMode: ParseMode.Html,
                    replyToMessageId: message.MessageId,
                    cancellationToken: cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Command.FlipLogic
{
    public class FlipHandler : AbstractHandler<FlipRequest>
    {
        public FlipHandler(IBotClient bot, ILogger<AbstractHandler<FlipRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(FlipRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var rnd = new Random();

            var coin = rnd.Next(2);

            string toss;
            
            toss = coin == 1 ? "cara" : "cruz";
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: $"<i>No soy monedita de oro pa' caerle bien a todos</i>, pero la moneda ha caido en <b>{toss}</b>.",
                parseMode: ParseMode.Html,
                replyToMessageId: message.MessageId,
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}
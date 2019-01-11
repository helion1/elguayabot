using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Command.PingPongLogic
{
    public class PingPongHandler: AbstractHandler<PingPongRequest>
    {
        public PingPongHandler(BlockingTelegramBotClient bot, ILogger<AbstractHandler<PingPongRequest>> logger) : base(bot, logger)
        {
        }
        
        public override async Task<Unit> Handle(PingPongRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var sentDate = message.Date;
            var receivedDate = DateTime.UtcNow;
            var difference = (receivedDate - sentDate) * 1;
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: $"pong! He tardado `{difference.TotalSeconds:N2}` milisegundos en recibir tu mensaje. Los mismos que duras tu en la cama, muerdealmohadas",
                parseMode: ParseMode.Markdown
            );
            
            return Unit.Value;
        }
    }
}
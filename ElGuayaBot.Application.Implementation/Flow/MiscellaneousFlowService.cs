using System;
using System.Globalization;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class MiscellaneousFlowService: BaseFlowService, IMiscellaneousFlowService
    {
        public MiscellaneousFlowService(IBotClient bot) : base(bot)
        {
        }

        public async void PingPong(Message message)
        {
            var sentDate = message.Date;
            var receivedDate = DateTime.UtcNow;
            var difference = receivedDate - sentDate;
            
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: $"pong! He tardado `{difference.TotalSeconds:N2}` milisegundos en recibir tu mensaje.",
                parseMode: ParseMode.Markdown
            );
        }

        public async void FlipCoin(Message message)
        {
            var coin = Rnd.Next(2);

            string toss;
            
            toss = coin == 1 ? "cara" : "cruz";
            
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: $"La moneda ha caido en **{toss}**.",
                parseMode: ParseMode.Markdown
            );
        }
    }
}
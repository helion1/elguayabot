using System;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class PingPongFlow: BaseFlow, IPingPongFlow
    {
        public PingPongFlow(IBotClient bot) : base(bot)
        {
        }

        public override async void Initiate(Message message)
        {
            var sentDate = message.Date;
            var receivedDate = DateTime.UtcNow;
            var difference = receivedDate - sentDate;
            
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: $"pong! He tardado `{difference.TotalSeconds:N2}` milisegundos en recibir tu mensaje. Los mismos que duras tu en la cama, muerdealmohadas",
                parseMode: ParseMode.Markdown
            );       
        }
    }
}
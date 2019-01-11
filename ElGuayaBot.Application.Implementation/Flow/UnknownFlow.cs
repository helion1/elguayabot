using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class UnknownFlow: BaseFlow, IUnknownFlow
    {

        public UnknownFlow(IBotClient bot) : base(bot)
        {
        }
        
        public override async void Initiate(Message message)
        {
            var responses = new List<string>()
            {
                "No te entiendo maldito lázaro",
                "Sacate el huevo de la boca"
            };
            
            var r = Rnd.Next(responses.Count);

            var r2 = Rnd.Next(10);
            
            if (r2 == 1)
            {
                await _bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: responses[r],
                    replyToMessageId: message.MessageId
                );
            }
        }

    }
}
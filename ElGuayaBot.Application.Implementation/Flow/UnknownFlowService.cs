using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class UnknownFlowService: BaseFlowService, IUnknownFlowService
    {

        public UnknownFlowService(IBotClient bot) : base(bot)
        {
        }
        
        public async void UnknownCommand(Message message)
        {
            var text = message.Text;
            
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: "No te entiendo maldito lázaro"
                );
        }

    }
}
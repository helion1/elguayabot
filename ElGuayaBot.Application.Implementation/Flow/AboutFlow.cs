using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class AboutFlow: BaseFlow, IAboutFlow
    {
        public AboutFlow(IBotClient bot) : base(bot)
        {
        }
        
        public override async void Initiate(Message message)
        {
            var aboutText = "[ElGuayaBot](https://github.com/elementh/elguayabot), made with humor and code by [Lucas](https://github.com/elementh) and [Daniel](https://github.com/Zabrios) for our friend [Jose](https://github.com/ElGuayaba)";
            
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: aboutText,
                parseMode: ParseMode.Markdown
            );
            
        }
    }
}
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class FlipCoinFlow: BaseFlow, IFlipCoinFlow
    {
        public FlipCoinFlow(IBotClient bot) : base(bot)
        {
        }

        public override async void Initiate(Message message)
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
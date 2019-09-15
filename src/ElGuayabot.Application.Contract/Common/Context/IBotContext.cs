using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Common.Client;
using ElGuayabot.Application.Contract.Model;
using Telegram.Bot.Types;

namespace ElGuayabot.Application.Contract.Common.Context
{
    public interface IBotContext
    {
        IBotClient BotClient { get; set; }
        Message Message { get; set; }
        CallbackQuery CallbackQuery { get; set; }
        InlineQuery InlineQuery { get; set; }
        User User { get; set; }
        Chat Chat { get; set; }
        
        Task Populate(Message message);
        void Populate(CallbackQuery callbackQuery);
        void Populate(InlineQuery inlineQuery);
    }
}
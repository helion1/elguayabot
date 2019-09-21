using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Common.Client;
using Telegram.Bot.Types;
using Chat = ElGuayabot.Domain.Entity.Chat;
using User = ElGuayabot.Domain.Entity.User;

namespace ElGuayabot.Application.Contract.Common.Context
{
    public interface IBotContext
    {
        IBotClient BotClient { get; set; }
        Message Message { get; set; }
        Update Update { get; set; }
        CallbackQuery CallbackQuery { get; set; }
        InlineQuery InlineQuery { get; set; }
        User User { get; set; }
        Chat Chat { get; set; }

        Task Populate(Message message);
        Task Populate(Update update);
    }
}
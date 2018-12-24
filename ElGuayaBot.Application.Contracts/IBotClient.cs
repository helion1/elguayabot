using MihaZupan.TelegramBotClients;
using Telegram.Bot;

namespace ElGuayaBot.Application.Contracts
{
    public interface IBotClient
    {
        BlockingTelegramBotClient Client { get; }
    }
}

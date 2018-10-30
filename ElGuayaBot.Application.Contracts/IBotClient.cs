using Telegram.Bot;

namespace ElGuayaBot.Application.Contracts
{
    public interface IBotClient
    {
        TelegramBotClient Client { get; }
    }
}

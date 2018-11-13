using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Contracts
{
    public interface IBotClient
    {
        BlockingTelegramBotClient Client { get; }
    }
}

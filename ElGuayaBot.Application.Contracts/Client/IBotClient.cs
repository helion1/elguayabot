using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Contracts.Client
{
    public interface IBotClient
    {
        BlockingTelegramBotClient Client { get; }
    }
}

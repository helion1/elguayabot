using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Contract.Client
{
    public interface IBotClient
    {
        BlockingTelegramBotClient Client { get; }
    }
}

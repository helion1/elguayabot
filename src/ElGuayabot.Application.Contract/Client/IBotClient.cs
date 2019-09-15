using MihaZupan.TelegramBotClients;

namespace ElGuayabot.Application.Contract.Client
{
    public interface IBotClient
    {
        BlockingTelegramBotClient Client { get; }
    }
}

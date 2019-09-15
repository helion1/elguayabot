using MihaZupan.TelegramBotClients;

namespace ElGuayabot.Application.Contract.Common.Client
{
    public interface IBotClient
    {
        BlockingTelegramBotClient Client { get; }
        void Start();
    }
}
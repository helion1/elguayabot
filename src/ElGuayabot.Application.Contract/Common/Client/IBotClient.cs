using MihaZupan.TelegramBotClients;

namespace ElGuayabot.Application.Contract.Common.Client
{
    public interface IBotClient
    {
        RateLimitedTelegramBotClient Client { get; }
        void Start();
    }
}
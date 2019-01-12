using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Contracts.Flow
{
    public interface IBaseFlow
    {
        void Initiate(Message message);
    }
}
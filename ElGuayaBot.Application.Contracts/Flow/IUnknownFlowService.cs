using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Contracts.Flow
{
    public interface IUnknownFlowService
    {
        void UnknownCommand(Message message);
    }
}
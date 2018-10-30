using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Contracts.Flow
{
    public interface IRandomTextFlowService
    {
        void PatternRecognizer(Message message);
    }
}
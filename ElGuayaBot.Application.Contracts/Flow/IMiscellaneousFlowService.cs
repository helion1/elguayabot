using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Contracts.Flow
{
    public interface IMiscellaneousFlowService
    {
        void PingPong(Message message);

        void FlipCoin(Message message);
    }
}
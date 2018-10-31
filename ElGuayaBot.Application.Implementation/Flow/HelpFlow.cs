using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class HelpFlow: BaseFlow, IHelpFlow
    {
        public HelpFlow(IBotClient bot) : base(bot)
        {
        }

        public override void Initiate(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}
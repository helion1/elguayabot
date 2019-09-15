using ElGuayabot.Application.Contract.BotActions.Common;
using ElGuayabot.Application.Contract.Common.Context;

namespace ElGuayaBot.Application.Implementation.BotActions.Common
{
    public abstract class CommandAction : BotAction, ICommandAction
    {
        public CommandAction(IBotContext botContext) : base(botContext)
        {
        }
    }
}
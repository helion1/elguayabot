using ElGuayabot.Application.Contract.Common.Context;

namespace ElGuayabot.Application.Contract.Model.Action.Command
{
    public abstract class CommandAction : BotAction, ICommandAction
    {
        public CommandAction(IBotContext botContext) : base(botContext)
        {
        }
    }
}
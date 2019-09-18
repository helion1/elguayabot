using ElGuayabot.Application.Contract.Common.Context;

namespace ElGuayabot.Application.Contract.Model.Action.Miscellaneous
{
    public abstract class MiscellaneousAction : BotAction, IMiscellaneousAction
    {
        public MiscellaneousAction(IBotContext botContext) : base(botContext)
        {
        }
    }
}
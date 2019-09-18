using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Application.Contract.Model.Action.Update
{
    public abstract class UpdateAction : BotAction, IBotAction
    {
        public UpdateAction(IBotContext botContext) : base(botContext)
        {
        }
    }
}
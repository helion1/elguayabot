using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Application.Contract.Model.Action.Update
{
    public abstract class UpdateAction : BotAction, IUpdateAction
    {
        public Telegram.Bot.Types.Update Update { get; set; }
        public UpdateAction(IBotContext botContext) : base(botContext)
        {
            Update = botContext.Update;
        }

    }
}
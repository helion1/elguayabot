using ElGuayabot.Application.Contract.BotActions.Common;
using ElGuayabot.Application.Contract.Common.Context;

namespace ElGuayaBot.Application.Implementation.BotActions.Common
{
    public abstract class InlineAction : BotAction, IInlineAction
    {
        public string Query { get; set; }
        public string Offset { get; set; }
     
        public InlineAction(IBotContext botContext) : base(botContext)
        {
            Query = botContext.InlineQuery?.Query;
            Offset = botContext.InlineQuery?.Offset;
        }
    }
}
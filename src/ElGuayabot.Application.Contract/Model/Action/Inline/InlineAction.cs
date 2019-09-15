using ElGuayabot.Application.Contract.Common.Context;

namespace ElGuayabot.Application.Contract.Model.Action.Inline
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
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.ButGold
{
    public class ButGoldMiscellaneousAction : MiscellaneousAction
    {
        public ButGoldMiscellaneousAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition.ToLower().Contains("old");
        }
    }
}
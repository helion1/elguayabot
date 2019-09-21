using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.ColdMeat
{
    public class ColdMeatMiscellaneousAction : MiscellaneousAction
    {
        public ColdMeatMiscellaneousAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition.ToLower().Contains("i'm hungry");
        }
    }
}
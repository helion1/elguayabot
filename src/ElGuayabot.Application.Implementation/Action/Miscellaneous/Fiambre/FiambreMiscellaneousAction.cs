using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.Fiambre
{
    public class FiambreMiscellaneousAction : MiscellaneousAction
    {
        public FiambreMiscellaneousAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return (condition.ToLower().Contains("tengo hambre") && !condition.ToLower().Contains("no tengo hambre"));
        }
    }
}
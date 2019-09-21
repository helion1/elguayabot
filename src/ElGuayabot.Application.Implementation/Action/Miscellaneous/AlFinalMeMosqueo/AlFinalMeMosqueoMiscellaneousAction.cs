using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.AlFinalMeMosqueo
{
    public class AlFinalMeMosqueoMiscellaneousAction : MiscellaneousAction
    {
        public AlFinalMeMosqueoMiscellaneousAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition.ToLower().Contains("al final me mosqueo");
        }
    }
}
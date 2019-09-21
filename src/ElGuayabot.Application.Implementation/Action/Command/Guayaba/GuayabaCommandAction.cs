using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Command;

namespace ElGuayabot.Application.Implementation.Action.Command.Guayaba
{
    public class GuayabaCommandAction : CommandAction
    {
        public GuayabaCommandAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "/guayaba" || condition == "/fruta";
        }
    }
}
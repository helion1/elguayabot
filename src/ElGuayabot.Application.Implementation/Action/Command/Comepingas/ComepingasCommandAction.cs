using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Command;

namespace ElGuayabot.Application.Implementation.Action.Command.Comepingas
{
    public class ComepingasCommandAction : CommandAction
    {
        public ComepingasCommandAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "/comepingas";
        }
    }
}
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Command;

namespace ElGuayabot.Application.Implementation.Action.Command.Echo
{
    public class EchoCommandAction : CommandAction
    {
        public EchoCommandAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "/echo";
        }
    }
}
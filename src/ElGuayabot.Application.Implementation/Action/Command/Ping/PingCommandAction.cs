using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Command;

namespace ElGuayabot.Application.Implementation.Action.Command.Ping
{
    public class PingCommandAction : CommandAction
    {
        public PingCommandAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "/ping";
        }
    }
}
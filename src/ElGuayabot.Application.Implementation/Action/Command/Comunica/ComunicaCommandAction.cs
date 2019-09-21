using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Command;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Application.Implementation.Action.Command.Comunica
{
    public class ComunicaCommandAction : CommandAction
    {
        public ComunicaCommandAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "/comunica" && Chat.Type == Chat.ChatType.Private && From.IsAdmin;;
        }
    }
}
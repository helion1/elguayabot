using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Command;
using Telegram.Bot.Types;

namespace ElGuayabot.Application.Implementation.Action.Command.Comepingas
{
    public class ComepingasCommandAction : CommandAction
    {
        public Message Message { get; set; }
        
        public ComepingasCommandAction(IBotContext botContext) : base(botContext)
        {
            Message = botContext.Message;
        }

        public override bool CanHandle(string condition)
        {
            return condition == "/comepingas";
        }
    }
}
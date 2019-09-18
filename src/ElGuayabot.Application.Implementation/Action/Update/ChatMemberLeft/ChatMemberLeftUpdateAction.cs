using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Update;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberLeft
{
    public class ChatMemberLeftUpdateAction : UpdateAction
    {
        public ChatMemberLeftUpdateAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "ChatMemberLeft";
        }
    }
}
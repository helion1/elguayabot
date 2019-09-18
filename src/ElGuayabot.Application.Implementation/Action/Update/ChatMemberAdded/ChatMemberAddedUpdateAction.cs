using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Update;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberAdded
{
    public class ChatMemberAddedUpdateAction : UpdateAction
    {
        public ChatMemberAddedUpdateAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "ChatMembersAdded";
        }
    }
}
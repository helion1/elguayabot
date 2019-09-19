using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Update;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatTitleChanged
{
    public class ChatTitleChangedUpdateAction : UpdateAction
    {
        public ChatTitleChangedUpdateAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "ChatTitleChanged";
        }
    }
}
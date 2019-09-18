using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Update;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberAdded
{
    public class ChatMemberAddedUpdateAction : UpdateAction
    {
//        var message = "Bienvenido a la noble causa del bolivarismo.";
//                
//            if (newUsers.Count() == 1)
//        {
//            message = $"Bienvenido @{newUsers.First().Username} a la noble causa del bolivarismo.";
//        }
//        else if (newUsers.Count > 1)
//        {
////                    var usernames = newUsers.Select(user => user.Username).ToList();
//            //TODO: get all usernames
//            message = $"Bienvenidos todos a la noble causa del bolivarismo.";
//        }

        public ChatMemberAddedUpdateAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition == "ChatMemberAdded";
        }
    }
}
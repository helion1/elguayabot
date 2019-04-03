using System.Linq;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatMemberAddedHandler : NotificationHandler<UpdateNotification>
    {
        private readonly IMediator _mediatR;

        public UpdateNotificationChatMemberAddedHandler(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        protected override void Handle(UpdateNotification notification)
        {
            if (notification.Type != UpdateType.ChatMembersAdded) return;

            var newUsers = notification.NewChatMembers.Where(chatMember => !chatMember.IsBot).ToList();

            var message = "Bienvenido a la noble causa del bolivarismo.";
            
            if (newUsers.Count() == 1)
            {
                message = $"Bienvenido @{newUsers.First().Username} a la noble causa del bolivarismo.";
            }
            else if (newUsers.Count > 1)
            {
//                var usernames = newUsers.Select(user => user.Username).ToList();
                //TODO: get all usernames
                message = $"Bienvenidos todos a la noble causa del bolivarismo.";
            }
        }
    }
}
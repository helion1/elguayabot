using System.Linq;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatMemberAddedHandler : NotificationHandler<UpdateNotification>

    {
        protected override void Handle(UpdateNotification notification)
        {
            if (notification.Type != UpdateType.ChatMembersAdded) return;

            var newUsers = notification.NewChatMembers.Where(chatMember => !chatMember.IsBot);

            
        }
    }
}
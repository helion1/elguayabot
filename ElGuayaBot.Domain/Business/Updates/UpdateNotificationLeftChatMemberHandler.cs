using ElGuayaBot.Domain.Business.Messages;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationLeftChatMemberHandler :  NotificationHandler<UpdateNotification>
    {
        private readonly IMediator _mediatR;

        public UpdateNotificationLeftChatMemberHandler(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        protected override void Handle(UpdateNotification notification)
        {
            if (notification.Type != UpdateType.ChatMemberLeft) return;
            
            var leftUser = notification.LeftChatMember;

            if (leftUser.IsBot) return;
            
            _mediatR.Publish(new SendMessageRequest()
            {
                ChatId = notification.ChatId,
                Message = $"@{leftUser.Username} murió combatiendo el imperialismo. ",
            });
        }
    }
}
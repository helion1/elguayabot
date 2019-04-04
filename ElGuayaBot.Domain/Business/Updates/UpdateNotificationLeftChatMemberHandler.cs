using ElGuayaBot.Domain.Business.Messages;
using ElGuayaBot.Domain.Business.UserChat.DeleteUserFromChat;
using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contract;
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

            _mediatR.Send(new DeleteUserFromChatCommand()
            {
                UserId = leftUser.Id,
                ChatId = notification.ChatId
            });
        }
    }
}
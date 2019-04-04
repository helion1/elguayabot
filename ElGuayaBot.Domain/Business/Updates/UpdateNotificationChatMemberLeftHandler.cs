using ElGuayaBot.Domain.Business.ChatsUsers.DeleteUserFromChat;
using ElGuayaBot.Domain.Business.Messages;
using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contract;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatMemberLeftHandler :  NotificationHandler<UpdateNotification>
    {
        private readonly IMediator _mediatR;
        public UpdateNotificationChatMemberLeftHandler(IMediator mediatR)
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

            _mediatR.Send(new DeleteChatUserCommand()
            {
                UserId = leftUser.Id,
                ChatId = notification.ChatId
            });
        }
    }
}
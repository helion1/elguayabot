using ElGuayaBot.Domain.Business.ChatsUsers.DeleteUserFromChat;
using ElGuayaBot.Domain.Business.Requests;
using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatMemberLeftHandler :  NotificationHandler<UpdateNotification>
    {
        private readonly Logger<UpdateNotificationChatMemberLeftHandler> Logger;
        private readonly IMediator _mediatR;

        public UpdateNotificationChatMemberLeftHandler(Logger<UpdateNotificationChatMemberLeftHandler> logger, IMediator mediatR)
        {
            Logger = logger;
            _mediatR = mediatR;
        }

        protected override void Handle(UpdateNotification notification)
        {
            if (notification.Type != UpdateType.ChatMemberLeft) return;
            Logger.LogTrace($"ChatMemberLeft update handler triggered.");

            var leftUser = notification.LeftChatMember;

            if (leftUser.IsBot) return;
            
            _mediatR.Publish(new SendMessageRequest()
            {
                ChatId = notification.ChatId,
                Message = $"@{leftUser.Username} murió combatiendo el imperialismo.",
            });

            _mediatR.Send(new DeleteChatUserCommand()
            {
                UserId = leftUser.Id,
                ChatId = notification.ChatId
            });
        }
    }
}
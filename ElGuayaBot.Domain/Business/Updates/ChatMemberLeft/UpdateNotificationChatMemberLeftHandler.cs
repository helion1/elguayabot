using ElGuayaBot.Domain.Business.ChatsUsers.DeleteUserFromChat;
using ElGuayaBot.Domain.Business.Requests;
using ElGuayaBot.Domain.Business.Updates.Common;
using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatMemberLeftHandler :  NotificationHandler<UpdateCommand>
    {
        private readonly Logger<UpdateNotificationChatMemberLeftHandler> Logger;
        private readonly IMediator _mediatR;

        public UpdateNotificationChatMemberLeftHandler(Logger<UpdateNotificationChatMemberLeftHandler> logger, IMediator mediatR)
        {
            Logger = logger;
            _mediatR = mediatR;
        }

        protected override void Handle(UpdateCommand command)
        {
            if (command.Type != UpdateType.ChatMemberLeft) return;
            Logger.LogTrace($"ChatMemberLeft update handler triggered.");

            var leftUser = command.LeftChatMember;

            if (leftUser.IsBot) return;
            
            _mediatR.Publish(new SendMessageRequest()
            {
                ChatId = command.ChatId,
                Message = $"@{leftUser.Username} murió combatiendo el imperialismo.",
            });

            _mediatR.Send(new DeleteChatUserCommand()
            {
                UserId = leftUser.Id,
                ChatId = command.ChatId
            });
        }
    }
}
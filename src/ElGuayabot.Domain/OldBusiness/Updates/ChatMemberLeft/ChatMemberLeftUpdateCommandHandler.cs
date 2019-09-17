using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Business.ChatsUsers.DeleteUserFromChat;
using ElGuayabot.Domain.Business.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Business.Updates.ChatMemberLeft
{
    public class ChatMemberLeftUpdateCommandHandler : ElGuayabot.Common.Request.CommonHandler<ChatMemberLeftUpdateCommand, Result>
    {
        public ChatMemberLeftUpdateCommandHandler(ILogger<ElGuayabot.Common.Request.CommonHandler<ChatMemberLeftUpdateCommand, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ChatMemberLeftUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var leftUser = request.LeftChatMember;

                if (leftUser.IsBot) return Result.Success();
            
                await MediatR.Send(new DeleteChatUserCommand()
                {
                    UserId = leftUser.Id,
                    ChatId = request.ChatId
                }, cancellationToken);
                
                await MediatR.Publish(new SendMessage()
                {
                    ChatId = request.ChatId,
                    Message = $"@{leftUser.Username} murió combatiendo el imperialismo.",
                }, cancellationToken);

            }
            catch (Exception e)
            {
                Logger.LogError("Handler for 'ChatMemberLeftUpdateCommand' encountered an unknown error", e);
            }
            
            return Result.Success();
        }
    }
}
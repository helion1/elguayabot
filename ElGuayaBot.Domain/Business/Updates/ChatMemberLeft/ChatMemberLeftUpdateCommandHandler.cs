using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Business.ChatsUsers.DeleteUserFromChat;
using ElGuayaBot.Domain.Business.Requests;
using ElGuayaBot.Domain.Business.Updates.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates.ChatMemberLeft
{
    public class ChatMemberLeftUpdateCommandHandler : ElGuayaBot.Common.Request.RequestHandler<ChatMemberLeftUpdateCommand, Result>
    {
        public ChatMemberLeftUpdateCommandHandler(ILogger<ElGuayaBot.Common.Request.RequestHandler<ChatMemberLeftUpdateCommand, Result>> logger, IMediator mediatR) : base(logger, mediatR)
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
                
                await MediatR.Publish(new SendMessageRequest()
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
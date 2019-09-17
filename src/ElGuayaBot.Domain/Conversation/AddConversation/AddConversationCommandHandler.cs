using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Conversation.AddConversation
{
    internal class AddConversationCommandHandler : CommonHandler<AddConversationCommand, Result>
    {
        protected readonly IUnitOfWork UnitOfWork;
        
        public AddConversationCommandHandler(ILogger<CommonHandler<AddConversationCommand, Result>> logger, IMediator mediatR, IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            UnitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(AddConversationCommand request, CancellationToken cancellationToken)
        {
            var chat = await UnitOfWork.ChatRepository.Insert(request.ExtractChatModel());

            var user = await UnitOfWork.UserRepository.Insert(request.ExtractUserModel());

            var conversation = new Entity.Conversation
            {
                ChatId = chat.Id,
                Chat = chat,
                UserId = user.Id,
                User = user
            };
            
            chat.Conversations.Add(conversation);
            user.Conversations.Add(conversation);

            try
            {
                await UnitOfWork.SaveAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Unhandled error adding a new conversation. ChatId: {ChatId} UserId: {UserId}", chat.Id, user.Id);
                
                return Result.UnknownError(new List<string> {e.Message});
            }
            
            return Result.Success();
        }
    }
}
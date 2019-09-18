using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Chat
{
    public class UpdateChatTitleCommandHandler : CommonHandler<UpdateChatTitleCommand, Result>
    {
        protected readonly IUnitOfWork UnitOfWork;

        public UpdateChatTitleCommandHandler(ILogger<CommonHandler<UpdateChatTitleCommand, Result>> logger, IMediator mediatR, IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            UnitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(UpdateChatTitleCommand request, CancellationToken cancellationToken)
        {
            var chat = await UnitOfWork.ChatRepository.FindById(request.ChatId);

            if (chat == null) return Result.NotFound();

            chat.Title = request.Title;

            try
            {
                await UnitOfWork.SaveAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Unhandled error updating chat title. ChatId: {ChatId}", chat.Id);
                
                return Result.UnknownError(new List<string> {e.Message});
            }
            
            return Result.Success();
        }
    }
}
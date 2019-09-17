using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Business.Chats.ChangeChatTitle
{
    public class ChangeChatTitleCommandHandler : Common.Request.CommonHandler<ChangeChatTitleCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ChangeChatTitleCommandHandler(ILogger<Common.Request.CommonHandler<ChangeChatTitleCommand, Result>> logger, IMediator mediatR, IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(ChangeChatTitleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var chat = await _unitOfWork.ChatRepository.FindById(request.ChatId);

                chat.Title = request.NewChatTitle;

                _unitOfWork.ChatRepository.Update(chat);

                await _unitOfWork.SaveAsync();
            
                Logger.LogInformation($"Chat title for chat ({chat.Id}) has been changed to '{chat.Title}'.");
                
                return Result.Success();
            }
            catch (Exception e)
            {
                Logger.LogError("Handler for 'ChangeChatTitleCommand' encountered an unknown error", e);
            }
            
            return Result.Success();
        }
    }
}
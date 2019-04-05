using System.Threading.Tasks;
using ElGuayaBot.Domain.Business.Updates.Common;
using ElGuayaBot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatTitleChangedHandler : NotificationHandler<UpdateRequest>
    {
        private readonly Logger<UpdateNotificationChatTitleChangedHandler> Logger;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateNotificationChatTitleChangedHandler(Logger<UpdateNotificationChatTitleChangedHandler> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            _unitOfWork = unitOfWork;
        }

        protected override async void Handle(UpdateRequest request)
        {
            if (request.Type != UpdateType.ChatTitleChanged) return;
            Logger.LogTrace($"ChatTitleChanged update handler triggered.");

            var chat = await _unitOfWork.ChatRepository.FindById(request.ChatId);

            chat.Title = request.NewChatTitle;

            _unitOfWork.ChatRepository.Update(chat);

            await _unitOfWork.SaveAsync();
            
            Logger.LogInformation($"Chat title for chat ({chat.Id}) has been changed to '{chat.Title}'.");

        }
    }
}
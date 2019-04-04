using System.Threading.Tasks;
using ElGuayaBot.Persistence.Contract;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatTitleChangedHandler : NotificationHandler<UpdateNotification>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNotificationChatTitleChangedHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async void Handle(UpdateNotification notification)
        {
            if (notification.Type != UpdateType.ChatTitleChanged) return;

            var chat = await _unitOfWork.ChatRepository.FindById(notification.ChatId);

            chat.Title = notification.NewChatTitle;

            _unitOfWork.ChatRepository.Update(chat);

            await _unitOfWork.SaveAsync();
        }
    }
}
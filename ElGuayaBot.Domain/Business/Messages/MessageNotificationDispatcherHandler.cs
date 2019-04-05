using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Messages
{
    public class MessageNotificationDispatcherHandler : NotificationHandler<MessageCommand>
    {
        private readonly Logger<MessageNotificationDispatcherHandler> Logger;
        private readonly IMediator _mediatR;

        public MessageNotificationDispatcherHandler(Logger<MessageNotificationDispatcherHandler> logger, IMediator mediatR)
        {
            Logger = logger;
            _mediatR = mediatR;
        }

        protected override void Handle(MessageCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
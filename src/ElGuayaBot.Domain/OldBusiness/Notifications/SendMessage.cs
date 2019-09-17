using MediatR;

namespace ElGuayabot.Domain.Business.Notifications
{
    public class SendMessage : INotification
    {
        public long ChatId { get; set; }
        public string Message { get; set; }
    }
}
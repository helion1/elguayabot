using MediatR;

namespace ElGuayaBot.Domain.Business.Messages
{
    public class SendMessageRequest : INotification
    {
        public long ChatId { get; set; }
        public string Message { get; set; }
    }
}
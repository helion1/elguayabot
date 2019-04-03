using MediatR;

namespace ElGuayaBot.Domain.Business.Messages
{
    public class SendMessageRequest : INotification
    {
        public long ChatId { get; set; }
        public long ReplyToMessageId { get; set; }
        public string Message { get; set; }
    }
}
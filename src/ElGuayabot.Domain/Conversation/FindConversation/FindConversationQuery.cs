using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Domain.Conversation.FindConversation
{
    public class FindConversationQuery : Request<Result<Entity.Conversation>>
    {
        public long ChatId { get; set; }
        public int UserId { get; set; }
    }
}
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Domain.Conversation.DeleteConversation
{
    public class DeleteConversationCommand : Request<Result>
    {
        /// <summary>
        /// Id of the chat.
        /// </summary>
        public long ChatId { get; set; }
        /// <summary>
        /// Id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}
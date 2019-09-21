using ElGuayabot.Domain.Conversation.DeleteConversation;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberLeft
{
    public static class ChatMemberLeftUpdateActionExtension
    {
        public static DeleteConversationCommand MapToDeleteConversationCommand(this ChatMemberLeftUpdateAction chatMemberLeftUpdateAction)
        {
            return new DeleteConversationCommand
            {
                ChatId = chatMemberLeftUpdateAction.Chat.Id,
                UserId = chatMemberLeftUpdateAction.From.Id
            };
        }
    }
}
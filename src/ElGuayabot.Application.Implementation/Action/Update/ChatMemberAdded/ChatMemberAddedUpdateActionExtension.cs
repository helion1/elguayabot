using ElGuayabot.Domain.Conversation.AddConversation;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberAdded
{
    public static class ChatMemberAddedUpdateActionExtension
    {
        public static AddConversationCommand MapToAddConversationCommand(this ChatMemberAddedUpdateAction chatMemberAddedUpdateAction)
        {
            return new AddConversationCommand();
        }
    }
}
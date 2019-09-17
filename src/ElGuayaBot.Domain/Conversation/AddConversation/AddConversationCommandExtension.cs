using System;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Domain.Conversation.AddConversation
{
    public static class AddConversationCommandExtension
    {
        public static Chat ExtractChatModel(this AddConversationCommand addConversationCommand)
        {
            return new Chat
            {
                Id = addConversationCommand.ChatId,
                Username = addConversationCommand.ChatUsername,
                Title = addConversationCommand.ChatTitle,
                Type = Enum.Parse<Chat.ChatType>(addConversationCommand.ChatType),
                FirstSeen = DateTime.Today.ToUniversalTime()
            };
        }

        public static User ExtractUserModel(this AddConversationCommand addConversationCommand)
        {
            return new User
            {
                Id = addConversationCommand.UserId,
                IsBot = addConversationCommand.UserIsBot,
                LanguageCode = addConversationCommand.UserLanguageCode,
                Username = addConversationCommand.UserUsername,
                FirstSeen = DateTime.Today.ToUniversalTime()
            };
        }
    }
}
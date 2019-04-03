using ElGuayaBot.Domain.Business.Updates;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UpdateType = ElGuayaBot.Domain.Business.Updates.UpdateType;

namespace ElGuayaBot.Application.Implementation.Mapping
{
    public static class UpdateMapper
    {
        public static UpdateNotification ToNotification(this Update update)
        {
            return new UpdateNotification()
            {
                Id = update.Id,
                Type = GetType(update),
                NewChatTitle = update.Message.NewChatTitle,
                LeftChatMember = update.Message.LeftChatMember.ToDomain(),
                NewChatMembers = update.Message.NewChatMembers.ToDomain(),
            };
        }

        public static UpdateType GetType(Update update)
        {
            switch (update.Message.Type)
            {
                case MessageType.ChatMemberLeft:
                    return UpdateType.ChatMemberLeft;
                case MessageType.ChatMembersAdded:
                    return UpdateType.ChatMembersAdded;
                case MessageType.ChatTitleChanged:
                    return UpdateType.ChatTitleChanged;
                default:
                    return UpdateType.Other;
            }
        }
    }
}
using ElGuayabot.Domain.Chat.UpdateChatTitle;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatTitleChanged
{
    public static class ChatTitleChangedUpdateActionExtension
    {
        public static UpdateChatTitleCommand MapToUpdateChatTitleCommand(this ChatTitleChangedUpdateAction chatTitleChangedUpdateAction)
        {
            return new UpdateChatTitleCommand
            {
                ChatId = chatTitleChangedUpdateAction.Chat.Id,
                Title = chatTitleChangedUpdateAction.Update.Message.NewChatTitle
            };
        }
    }
}
using ElGuayaBot.Domain.Entity;

namespace ElGuayaBot.Application.Implementation.Mapping
{
    public static class ChatMapper
    {
        public static Chat ToDomain(this Telegram.Bot.Types.Chat chat)
        {
            return new Chat()
            {
                Id = chat.Id,
                Title = chat.Title,
                Type = chat.Type.ToString()
            };
        }
    }
}
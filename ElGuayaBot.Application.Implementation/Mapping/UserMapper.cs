using ElGuayaBot.Domain.Entity;

namespace ElGuayaBot.Application.Implementation.Mapping
{
    public static class UserMapper
    {
        public static User ToDomain(this Telegram.Bot.Types.User user)
        {
            return new User()
            {
                Id = user.Id,
                Username = user.Username,
                IsBot = user.IsBot,
                LanguageCode = user.LanguageCode
            };
        }
    }
}
using System;
using Telegram.Bot;

namespace ElGuayaBot.Application.Contracts.Flow
{
    public abstract class BaseFlowService
    {
        protected static Random Rnd { get; set; }

        protected readonly ITelegramBotClient _bot;

        public BaseFlowService(IBotClient bot)
        {
            _bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
            Rnd = new Random();
        }
    }
}
using System;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using MihaZupan.TelegramBotClients;
using NeoSmart.Unicode;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public abstract class BaseFlow: IBaseFlow
    {
        protected static Random Rnd { get; set; }

        protected readonly BlockingTelegramBotClient _bot;

        public BaseFlow(IBotClient bot)
        {
            _bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
            Rnd = new Random();
        }
        

        public abstract void Initiate(Message message);
    }
}
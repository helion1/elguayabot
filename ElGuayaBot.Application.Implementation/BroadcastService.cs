using System;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Implementation.Flow;
using MihaZupan.TelegramBotClients;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation
{
    public class BroadcastService: IBroadcastService
    {

        protected readonly BlockingTelegramBotClient Bot;

        public BroadcastService(IBotClient bot)
        {
            Bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
        }

        public void CommunicateToAll(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class WelcomeMessageFlow : BaseFlow, IWelcomeMessageFlow
    {
        public WelcomeMessageFlow(IBotClient bot) : base(bot)
        {
        }

        public override async void Initiate(Message message)
        {
            foreach (var user in message.NewChatMembers)
            {
                if (!user.IsBot)
                {
                    await _bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"Bienvenido @{user.Username} a la noble causa del bolivarismo. ",
                        replyToMessageId: message.MessageId
                        );
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class LeftChatMessageFlow : BaseFlow, ILeftChatMessageFlow
    {
        public LeftChatMessageFlow(IBotClient bot) : base(bot)
        {
        }

        public override async void Initiate(Message message)
        {
            var user = message.LeftChatMember;

            try
            {
                if (!user.IsBot)
                {
                    await _bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"@{user.Username} murió combatiendo el imperialismo. ",
                        replyToMessageId: message.MessageId
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

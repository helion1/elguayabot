using System;
using System.Collections.Generic;
using System.Text;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
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

        }
    }
}

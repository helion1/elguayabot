using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class UnknownFlow: BaseFlow, IUnknownFlow
    {

        public UnknownFlow(IBotClient bot) : base(bot)
        {
        }
        
        public override async void Initiate(Message message)
        {

        }

    }
}
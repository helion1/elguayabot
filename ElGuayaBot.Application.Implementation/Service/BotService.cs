using System;
using System.Threading;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Application.Implementation.Logic.Common.EntityPersistenceLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.OnMessageDispatcherLogic;
using ElGuayaBot.Application.Implementation.Logic.OnUpdate.OnUpdateDispatcherLogic;
using MediatR;
using MihaZupan.TelegramBotClients;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Service
{
    public class BotService : IBotService
    {
        protected readonly BlockingTelegramBotClient Bot;
        
        protected readonly IMediator MediatR;

        public BotService(BlockingTelegramBotClient bot, IMediator mediatR)
        {
            Bot = bot;
            MediatR = mediatR;
        }

        public void FundarRepublica()
        {
            var me = Bot.GetMeAsync().Result;

            Bot.OnMessage += HandleEntityPeristance;
            Bot.OnMessage += HandleOnMessage;
            Bot.OnUpdate += HandleOnUpdate;
            Bot.OnMessageEdited += HandleOnMessageEdited;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            
            Console.WriteLine($"Start listening for @{me.Username}");

            Thread.Sleep(int.MaxValue);
        }
        
        private void HandleEntityPeristance(object sender, MessageEventArgs e)
        {
            MediatR.Send(new EntityPersistenceRequest { Message = e.Message });
        }

        private void HandleOnMessage(object sender, MessageEventArgs e)
        {
            MediatR.Send(new OnMessageDispatcherRequest { Message = e.Message });
        }

        private void HandleOnUpdate(object sender, UpdateEventArgs e)
        {
            MediatR.Send(new OnUpdateDispatcherRequest { Update = e.Update });
        }
        
        private void HandleOnMessageEdited(object sender, MessageEventArgs e)
        {
            //TODO
        }
    }
}
using System;
using System.Threading;
using ElGuayaBot.Application.Contract.Client;
using ElGuayaBot.Application.Contract.Service;
using ElGuayaBot.Application.Implementation.Logic.Common.EntityPersistenceLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.OnMessageDispatcherLogic;
using ElGuayaBot.Application.Implementation.Logic.OnUpdate.OnUpdateDispatcherLogic;
using ElGuayaBot.Application.Implementation.Mapping;
using ElGuayaBot.Domain.Business.UserChat.RegisterUserChat;
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

        public BotService(IBotClient bot, IMediator mediatR)
        {
            Bot = bot.Client;
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
            var chat = e.Message.Chat.ToDomain();
            var user = e.Message.From.ToDomain();
            
            MediatR.Send(new RegisterChatUserCommand
            {
                User = user,
                Chat = chat
            });
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
using System;
using System.Threading;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Application.Implementation.Logic.Common.EntityPersistenceLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.OnMessageDispatcherLogic;
using ElGuayaBot.Application.Implementation.Logic.OnUpdate.OnUpdateDispatcherLogic;
using ElGuayaBot.Persistence.Contracts;
using MediatR;
using MihaZupan.TelegramBotClients;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Service
{
    public class BotService : IBotService
    {
        private readonly BlockingTelegramBotClient _bot;
        
        private readonly IUnitOfWork _unitOfWork;
        
        protected readonly IMediator MediatR;

        public BotService(IBotClient bot, IUnitOfWork unitOfWork, IMediator mediatR)
        {
            _bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
            _unitOfWork = unitOfWork;
            MediatR = mediatR;
        }

        public void Start()
        {
            var me = _bot.GetMeAsync().Result;

            _bot.OnMessage += HandleEntityPeristance;
            _bot.OnMessage += HandleOnMessage;
//            _bot.OnMessageEdited += BotOnMessageReceived;
            _bot.OnUpdate += HandleOnUpdate;

            _bot.StartReceiving(Array.Empty<UpdateType>());
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
        
        private void BotOnUpdateReceived(object sender, UpdateEventArgs e)
        {
            try
            {
                var update = e.Update;
                if (update.Message != null)
                {
                    ProcessUpdateReceived(update);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ProcessUpdateReceived(Update update)
        {
//            var message = update.Message;
//            if (message.NewChatMembers != null)
//                _welcomeMessageFlow.Initiate(message);
//            if (message.LeftChatMember != null)
//                _leftChatMessageFlow.Initiate(message);
        }
    }
}
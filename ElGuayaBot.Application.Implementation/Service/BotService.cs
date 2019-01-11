using System;
using System.Linq;
using System.Threading;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Application.Implementation.Logic.Command.PingPongLogic;
using ElGuayaBot.Application.Implementation.Logic.Common.EntityPersistenceLogic;
using ElGuayaBot.Application.Implementation.Logic.OnMessage.OnMessageDispatcherLogic;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Model;
using MediatR;
using MihaZupan.TelegramBotClients;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Chat = ElGuayaBot.Persistence.Model.Chat;
using User = ElGuayaBot.Persistence.Model.User;

namespace ElGuayaBot.Application.Implementation.Service
{
    public class BotService : IBotService
    {
        private readonly BlockingTelegramBotClient _bot;
        
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IUnknownFlow _unknownFlow;
        private readonly IRandomTextFlow _randomTextFlow;
        private readonly IFlipCoinFlow _flipCoinFlow;
        private readonly IAboutFlow _aboutFlow;
        private readonly IHelpFlow _helpFlow;
        private readonly IComandanteFlow _comandanteFlow;
        private readonly IFrutaFlow _frutaFlow;
        private readonly IWelcomeMessageFlow _welcomeMessageFlow;
        private readonly IDabFlow _dabFlow;
        private readonly ILeftChatMessageFlow _leftChatMessageFlow;
        private readonly ITenorGifFlow _tenorGifFlow;
        private readonly IComunicaTest _comunicaTest;
        private readonly IPutoGuayabaFlow _putoGuayaba;
        
        protected readonly IMediator MediatR;

        public BotService(IBotClient bot,
            IUnknownFlow unknownFlow,
            IRandomTextFlow randomTextFlow,
            IFlipCoinFlow flipCoinFlow,
            IAboutFlow aboutFlow,
            IHelpFlow helpFlow,
            IComandanteFlow comandanteFlow,
            IFrutaFlow frutaFlow,
            IWelcomeMessageFlow welcomeMessageFlow,
            IDabFlow dabFlow,
            ILeftChatMessageFlow leftChatMessageFlow,
            ITenorGifFlow tenorGifFlow,
            IComunicaTest comunicaTest,
            IPutoGuayabaFlow putoGuayaba, 
            IUnitOfWork unitOfWork, IMediator mediatR)
        {
            _bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
            _unknownFlow = unknownFlow ?? throw new ArgumentNullException(nameof(bot));
            _randomTextFlow = randomTextFlow ?? throw new ArgumentNullException(nameof(bot));
            _flipCoinFlow = flipCoinFlow ?? throw new ArgumentNullException(nameof(bot));
            _aboutFlow = aboutFlow ?? throw new ArgumentNullException(nameof(bot));
            _helpFlow = helpFlow ?? throw new ArgumentNullException(nameof(bot));
            _comandanteFlow = comandanteFlow ?? throw new ArgumentNullException(nameof(bot));
            _frutaFlow = frutaFlow ?? throw new ArgumentNullException(nameof(bot));
            _welcomeMessageFlow = welcomeMessageFlow ?? throw new ArgumentNullException(nameof(bot));
            _dabFlow = dabFlow ?? throw new ArgumentNullException(nameof(bot));
            _leftChatMessageFlow = leftChatMessageFlow ?? throw new ArgumentNullException(nameof(bot));
            _tenorGifFlow = tenorGifFlow ?? throw new ArgumentNullException(nameof(bot));
            _comunicaTest = comunicaTest ?? throw new ArgumentNullException(nameof(bot));
            _putoGuayaba = putoGuayaba ?? throw new ArgumentNullException(nameof(bot));
            _unitOfWork = unitOfWork;
            MediatR = mediatR;
        }

        public void Start()
        {
            var me = _bot.GetMeAsync().Result;

            _bot.OnMessage += HandleEntityPeristance;
            _bot.OnMessage += HandleOnMessage;
//            _bot.OnMessageEdited += BotOnMessageReceived;
            _bot.OnUpdate += BotOnUpdateReceived;

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
            MediatR.Send(new OnMessageDispatcherRequest {Message = e.Message });
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
    
            if (message.SupergroupChatCreated)
            {
                //TODO

                return;
            }
            
            if (message.GroupChatCreated)
            {
                //TODO

                return;
            }

            if (message == null || message.Type != MessageType.Text)
            {
                return;
            }
            
            var firstWord = message.Text.Split(' ').First();
            var restOfText = message.Text.Substring(message.Text.IndexOf(' ') + 1);

            if (firstWord.StartsWith("/"))
            {
                await _bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                switch (firstWord)
                {
                    case "/about":
                        _aboutFlow.Initiate(message);
                        break;
                    case "/help":
                        _aboutFlow.Initiate(message);
                        break;
                    case "/ping":
                        await MediatR.Send(new PingPongRequest {Message = message});
                        break;
                    case "/flip":
                        _flipCoinFlow.Initiate(message);
                        break;
                    case "/comandante":
                        _comandanteFlow.Initiate(message);
                        break;
                    case "/fruta":
                        _frutaFlow.Initiate(message);
                        break;
                    case "/dab":
                        _dabFlow.Initiate(message);
                        break;
                    case "/comunica":
                        message.Text = restOfText;
                        _comunicaTest.Initiate(message);
                        break;
                    default:
                        if (message.Text.Split(' ').First().StartsWith("/"))
                        {
                            _unknownFlow.Initiate(message);
                        }
                        break;
                }
            }
            else
            {            
                if (message.Text.ToLower().Contains(".gif") && message.Text.ToLower().StartsWith("https://"))
                {
                    _tenorGifFlow.Initiate(message);
                }
                else
                {
                    if(message.Text.ToLower().Contains("puto guayaba"))
                    {
                        _putoGuayaba.Initiate(message);
                    }
                    else
                    {
                        _randomTextFlow.Initiate(message);
                    }

                }
            }
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
            var message = update.Message;
            if (message.NewChatMembers != null)
                _welcomeMessageFlow.Initiate(message);
            if (message.LeftChatMember != null)
                _leftChatMessageFlow.Initiate(message);
        }
    }
}
using System;
using System.Linq;
using System.Threading;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Model;
using MihaZupan.TelegramBotClients;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Chat = ElGuayaBot.Persistence.Model.Chat;
using User = ElGuayaBot.Persistence.Model.User;

namespace ElGuayaBot.Application.Implementation
{
    public class BotService : IBotService
    {
        private readonly BlockingTelegramBotClient _bot;
        
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IUnknownFlow _unknownFlow;
        private readonly IRandomTextFlow _randomTextFlow;
        private readonly IFlipCoinFlow _flipCoinFlow;
        private readonly IPingPongFlow _pingPongFlow;
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

        public BotService(IBotClient bot,
            IUnknownFlow unknownFlow,
            IRandomTextFlow randomTextFlow,
            IFlipCoinFlow flipCoinFlow,
            IPingPongFlow pingPongFlow,
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
            IUnitOfWork unitOfWork)
        {
            _bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
            _unknownFlow = unknownFlow ?? throw new ArgumentNullException(nameof(bot));
            _randomTextFlow = randomTextFlow ?? throw new ArgumentNullException(nameof(bot));
            _flipCoinFlow = flipCoinFlow ?? throw new ArgumentNullException(nameof(bot));
            _pingPongFlow = pingPongFlow ?? throw new ArgumentNullException(nameof(bot));
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
        }

        public void Start()
        {
            var me = _bot.GetMeAsync().Result;

            _bot.OnMessage += RegisterUserOrGroup;
            _bot.OnMessage += BotOnMessageReceived;
            _bot.OnMessageEdited += BotOnMessageReceived;
            _bot.OnUpdate += BotOnUpdateReceived;

            _bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @{me.Username}");

            Thread.Sleep(int.MaxValue);
        }

        private async void RegisterUserOrGroup(object sender, MessageEventArgs e)
        {

            try
            {
                    var chat = _unitOfWork.ChatRepository.GetById(e.Message.Chat.Id);

                    if (chat == null)
                    {
                    _unitOfWork.ChatRepository.Insert(new Chat
                    {
                        Id = e.Message.Chat.Id,
                        Type = e.Message.Chat.Type.ToString(),
                        Title = e.Message.Chat.Title,
                        FirstInteractionDate = DateTime.Now
                    });
                    
                    await _unitOfWork.SaveAsync();
                }
        
            }
            catch (Exception)
            {
                //TODO: Logs
            }
            
            try
            {
                var user = _unitOfWork.UserRepository.GetById(e.Message.From.Id);
        
                if (user == null)
                {
          
                    _unitOfWork.UserRepository.Insert(new User
                    {
                        Id = e.Message.From.Id,
                        Username = e.Message.From.Username,
                        LanguageCode = e.Message.From.LanguageCode,
                        IsBot = e.Message.From.IsBot,
                        FirstInteractionDate = DateTime.Now
                    });
                    
                    await _unitOfWork.SaveAsync();
                }
               
            }
            catch (Exception exception)
            {
                //TODO: Logs

            }
            


            
            try
            {
                var groupUser = _unitOfWork.ChatUserRepository.GetAll().FirstOrDefault(gu => gu.UserId == e.Message.From.Id && gu.ChatId == e.Message.Chat.Id);

                if (groupUser == null)
                {
                    _unitOfWork.ChatUserRepository.Insert(new ChatUser
                    {
                        ChatId = e.Message.Chat.Id,
                        UserId = e.Message.From.Id
                    });
                    
                    await _unitOfWork.SaveAsync();
                }

            }
            catch (Exception exception)
            {
                //TODO: logs
            }

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
                        _pingPongFlow.Initiate(message);
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
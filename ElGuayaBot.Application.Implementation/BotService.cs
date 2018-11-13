using System;
using System.Linq;
using System.Threading;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using MihaZupan.TelegramBotClients;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation
{
    public class BotService: IBotService
    {
        private readonly BlockingTelegramBotClient _bot;
        private readonly IUnknownFlow _unknownFlow;
        private readonly IRandomTextFlow _randomTextFlow;
        private readonly IFlipCoinFlow _flipCoinFlow;
        private readonly IPingPongFlow _pingPongFlow;
        private readonly IAboutFlow _aboutFlow;
        private readonly IHelpFlow _helpFlow;
        private readonly IComandanteFlow _comandanteFlow;
        private readonly IFrutaFlow _frutaFlow;

        public BotService(IBotClient bot, 
            IUnknownFlow unknownFlow, 
            IRandomTextFlow randomTextFlow,
            IFlipCoinFlow flipCoinFlow,
            IPingPongFlow pingPongFlow,
            IAboutFlow aboutFlow,
            IHelpFlow helpFlow,
            IComandanteFlow comandanteFlow,
            IFrutaFlow frutaFlow
            )
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
        }
        
        public void Start()
        {
            var me = _bot.GetMeAsync().Result;
            
            _bot.OnMessage += BotOnMessageReceived;
            _bot.OnMessageEdited += BotOnMessageReceived;
            
            _bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @{me.Username}");
            
            Thread.Sleep(int.MaxValue);
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null || message.Type != MessageType.Text)
            {
                return;
            }
            
            var firstWord = message.Text.Split(' ').First();

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
                        _pingPongFlow.Initiate(message) ;
                        break;
                    case "/flip":
                        _flipCoinFlow.Initiate(message) ;
                        break;
                    case "/comandante":
                        _comandanteFlow.Initiate(message);
                        break;
                    case "/fruta":
                        _frutaFlow.Initiate(message);
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
                _randomTextFlow.Initiate(message);
            }
        }

    }
}
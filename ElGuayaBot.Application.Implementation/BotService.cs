using System;
using System.Linq;
using System.Threading;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation
{
    public class BotService: IBotService
    {
        private readonly ITelegramBotClient _bot;
        private readonly IUnknownFlowService _unknownFlowService;
        private readonly IRandomTextFlowService _randomTextFlowService;
        private readonly IMiscellaneousFlowService _miscellaneousFlowService;

        public BotService(IBotClient bot, 
            IUnknownFlowService unknownFlowService, 
            IRandomTextFlowService randomTextFlowService,
            IMiscellaneousFlowService miscellaneousFlowService)
        {
            _bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
            _unknownFlowService = unknownFlowService ?? throw new ArgumentNullException(nameof(bot));
            _randomTextFlowService = randomTextFlowService ?? throw new ArgumentNullException(nameof(bot));
            _miscellaneousFlowService = miscellaneousFlowService ?? throw new ArgumentNullException(nameof(bot));
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
            
            await _bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            switch (message.Text.Split(' ').First())
            {
                case "/about":
                    break;
                case "/ping":
                    _miscellaneousFlowService.PingPong(message) ;
                    break;
                case "/flip":
                    _miscellaneousFlowService.FlipCoin(message) ;
                    break;
                default:
                    if (message.Text.Split(' ').First().StartsWith("/"))
                    {
                        _unknownFlowService.UnknownCommand(message);
                    }
                    else
                    {
                        _randomTextFlowService.PatternRecognizer(message);
                    }
                    
                    break;
                    
            }
        }

    }
}
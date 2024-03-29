using System;
using ElGuayabot.Application.Contract.Common.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Common.Client
{
    public class BotClient : IBotClient
    {
        protected readonly ILogger<BotClient> Logger;
        public RateLimitedTelegramBotClient Client { get; }
        
        public bool Started { get; set; }
        
        public BotClient(IConfiguration configuration, ILogger<BotClient> logger)
        {
            Started = false;
            Logger = logger;
            
            try
            {
                Client = string.IsNullOrWhiteSpace(configuration["TELEGRAM_TOKEN"]) 
                    ? new RateLimitedTelegramBotClient(configuration["Telegram:Token"]) 
                    : new RateLimitedTelegramBotClient(configuration["TELEGRAM_TOKEN"]);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error setting TelegramBotClient.");
                
                throw;
            }
        }

        public void Start()
        {
            if (Started == false)
            {
                var me = Client.GetMeAsync().Result;

                Client.StartReceiving(Array.Empty<UpdateType>());
                
                Logger.LogInformation($"Telegram Bot Client is receiving updates for bot: @{me.Username}");

                return;
            }
            
            Logger.LogWarning("Tried to start Telegram Bot Client update receiving when it's already running");
        }
    }
}
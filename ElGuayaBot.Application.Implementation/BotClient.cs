using System;
using System.Net.Http;
using ElGuayaBot.Application.Contracts;
using Microsoft.Extensions.Configuration;
using MihaZupan.TelegramBotClients;
using Telegram.Bot;

namespace ElGuayaBot.Application.Implementation
{
    public class BotClient: IBotClient
    {
        public BlockingTelegramBotClient Client { get; }
 
         public BotClient(IConfiguration configuration)
         {
             try
             {
                 Client = new BlockingTelegramBotClient(configuration["TelegramBotToken"], (HttpClient) null/*, new SchedulerSettings(60, 10, 500, 6, 1500, 6)*/);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 throw;
             }
         }
     }
 }
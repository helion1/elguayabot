using System;
using ElGuayaBot.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace ElGuayaBot.Application.Implementation
{
    public class BotClient: IBotClient
    {
        public TelegramBotClient Client { get; }
 
         public BotClient(IConfiguration configuration)
         {
             try
             {
                 Client = new TelegramBotClient(configuration["TelegramBotToken"]);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 throw;
             }
         }
     }
 }
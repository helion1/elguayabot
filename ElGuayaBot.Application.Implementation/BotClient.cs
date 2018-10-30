using System;
using ElGuayaBot.Application.Contracts;
using Telegram.Bot;

namespace ElGuayaBot.Application.Implementation
{
    public class BotClient: IBotClient
    {
        public TelegramBotClient Client { get; }
 
         public BotClient()
         {
             Client = new TelegramBotClient("INSERT YOUR CODE HERE");
         }
     }
 }
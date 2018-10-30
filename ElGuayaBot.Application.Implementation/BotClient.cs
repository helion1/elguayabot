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
             Client = new TelegramBotClient("723700092:AAGSRwCNGMVLDH_8oMee4blz_DD9MfeYN_4");
         }
     }
 }
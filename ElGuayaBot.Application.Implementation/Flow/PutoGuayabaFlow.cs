using System;
using System.IO;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class PutoGuayabaFlow : BaseFlow, IPutoGuayabaFlow
    {
        private static readonly Random randomNum = new Random();
        /// <summary>
        /// TO-DO PASTE THIS SHIT INTO A RESOURCES FILE OR WHATEVER
        /// </summary>
        private static string[] gifs = { "CgADBAADpwQAAv5ngVGtCPQFsb8tdAI", "CgADBAADqgQAAmU3gFHy16mGSB-vaQI", "CgADBAADqwQAAmU3gFF-jYzn6DPQcgI" };

        public PutoGuayabaFlow(IBotClient bot) : base(bot)
        {
        }

        public override async void Initiate(Message message)
        {
            try
            {
                GetRandomNumber();
                await _bot.SendDocumentAsync(
                        chatId: message.Chat.Id,
                        document: gifs[GetRandomNumber()],
                        replyToMessageId: message.MessageId
                        );
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetRandomNumber()
        {
            lock (randomNum)
            {
                return randomNum.Next(0, 3);
            }
        }
    }
}

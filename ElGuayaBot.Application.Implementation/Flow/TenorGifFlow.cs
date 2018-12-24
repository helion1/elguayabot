using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class TenorGifFlow : BaseFlow, ITenorGifFlow
    {
        public TenorGifFlow(IBotClient bot) : base(bot)
        {
        }

        public override async void Initiate(Message message)
        {
            string url = message.Text;

            try
            {
                if (CheckWebsite(url))
                {
                    await _bot.SendDocumentAsync(
                    chatId: message.Chat.Id,
                    document: url,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyToMessageId: message.MessageId
                    );
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private bool CheckWebsite(string URL)
        {
            try
            {
                WebClient wc = new WebClient();
                string HTMLSource = wc.DownloadString(URL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

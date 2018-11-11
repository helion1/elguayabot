using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class ComandanteFlow : BaseFlow, IComandanteFlow
    {
        public ComandanteFlow(IBotClient bot) : base(bot)
        {
        }

        public override async void Initiate(Message message)
        {
            string html = GetHtmlCode();
            List<string> urls = GetUrls(html);
            var rnd = new Random();

            int randomUrl = rnd.Next(0, urls.Count - 1);
            string luckyUrl = urls[randomUrl];

            await _bot.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: luckyUrl,
                caption: "@AlamoJose, ¡abajo el Imperialismo!",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                replyToMessageId: message.MessageId
                );
        }

        private string GetHtmlCode()
        {
            List<string> _topics = new List<string> { "nicolas maduro", "hugo chavez", "venezuela flag" };
            var rnd = new Random();

            int topic = rnd.Next(0, _topics.Count - 1);

            string url = "https://www.google.com/search?q=" + _topics[topic] + "&tbm=isch";
            string data = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return "";
                using (var sr = new StreamReader(dataStream))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        private List<string> GetUrls(string html)
        {
            var urls = new List<string>();

            int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);

            while (ndx >= 0)
            {
                ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
                ndx++;
                int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
                string url = html.Substring(ndx, ndx2 - ndx);
                urls.Add(url);
                ndx = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
            }
            return urls;
        }
    }
}


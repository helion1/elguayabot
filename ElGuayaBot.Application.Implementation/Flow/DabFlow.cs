using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ElGuayaBot.Application.Contracts.Client;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class DabFlow : BaseFlow, IDabFlow
    {
        public DabFlow(IBotClient bot) : base(bot)
        {
        }

        public string GetHtmlCode()
        {
            List<string> _topics = new List<string> { "dab gif" };
            var rnd = new Random();

            try
            {
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> GetUrls(string html)
        {
            var urls = new List<string>();

            try
            {
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckGifUrlExtension(string url)
        {
            var extension = url.Substring(url.Length - 4);
            if (string.Equals(extension, ".gif"))
                return true;
            else
                return false;
        }

        public override async void Initiate(Message message)
        {
            string html = GetHtmlCode();
            List<string> urls = GetUrls(html);
            var rnd = new Random();

            try
            {
                int randomUrl = rnd.Next(0, urls.Count - 1);
                string luckyUrl = urls[randomUrl];

                if (CheckGifUrlExtension(luckyUrl))
                {
                    await _bot.SendDocumentAsync(
                    chatId: message.Chat.Id,
                    document: luckyUrl,
                    caption: "Dabbing for VNZL",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    replyToMessageId: message.MessageId
                    );
                }
                else
                {
                    await _bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "No he podido encontrar un dab adecuado. USA debe haberlo embargado. Vuelve a intentarlo.",
                        replyToMessageId: message.MessageId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

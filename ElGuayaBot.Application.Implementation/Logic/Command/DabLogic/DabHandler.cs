using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Command.DabLogic
{
    public class DabHandler : AbstractHandler<DabRequest>
    {
        public DabHandler(IBotClient bot, ILogger<AbstractHandler<DabRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(DabRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            
            string html = GetHtmlCode();
            List<string> urls = GetUrls(html);
            var rnd = new Random();

            try
            {
                int randomUrl = rnd.Next(0, urls.Count - 1);
                string luckyUrl = urls[randomUrl];

                if (CheckUrlForGifExtension(luckyUrl))
                {
                    await Bot.SendDocumentAsync(
                        chatId: message.Chat.Id,
                        document: luckyUrl,
                        caption: "Dabbing for VNZL",
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                        cancellationToken: cancellationToken);
                }
                else
                {
                    await Bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "No he podido encontrar un dab adecuado. USA debe haberlo embargado. Vuelve a intentarlo.",
                        cancellationToken: cancellationToken);
                }
            }
            catch (Exception e)
            {
                Logger.LogError("Error handling Dab Request", e);
            }
            
            return Unit.Value;
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
            catch (Exception e)
            {
                Logger.LogError("Error getting Dab URls", e);

                throw;
            }
        }

        private bool CheckUrlForGifExtension(string url)
        {
            var extension = url.Substring(url.Length - 4);
            
            return string.Equals(extension, ".gif");
        }
        
        private string GetHtmlCode()
        {
            List<string> topics = new List<string> { "dab gif" };
            var rnd = new Random();

            try
            {
                int topic = rnd.Next(0, topics.Count - 1);

                string url = "https://www.google.com/search?q=" + topics[topic] + "&tbm=isch";
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
            catch (Exception e)
            {
                Logger.LogError("Error getting Dab HTML code", e);

                throw;
            }
        }

    }
}
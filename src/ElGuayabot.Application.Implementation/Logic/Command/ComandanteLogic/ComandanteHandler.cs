using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Logic.Command.ComandanteLogic
{
    public class ComandanteHandler : AbstractHandler<ComandanteRequest>
    {
        public ComandanteHandler(IBotClient bot, ILogger<AbstractHandler<ComandanteRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(ComandanteRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            string html = GetHtmlCode();
            List<string> urls = GetUrls(html);
            var rnd = new Random();
            
            try
            {
                int randomUrl = rnd.Next(0, urls.Count - 1);
                string luckyUrl = urls[randomUrl];
                var idsjoder = message.Chat.Id;

                await Bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: luckyUrl,
                    caption: "Hasta la victoria, siempre!",
                    parseMode: ParseMode.Html, 
                    cancellationToken: cancellationToken
                );
            }
            catch (Exception e)
            {
                Logger.LogError("Error handling Comandante Request", e);
            }
            
            return Unit.Value;
        }

        private string GetHtmlCode()
        {
            List<string> _topics = new List<string> { "nicolas maduro", "hugo chavez", "venezuela flag" };
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
            catch (Exception e)
            {
                Logger.LogError("Error getting Comandante HTML code", e);

                throw;
            }
        }

        private List<string> GetUrls(string html)
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
                Logger.LogError("Error getting Comandante URls", e);

                throw;
            }
        }
    }
}
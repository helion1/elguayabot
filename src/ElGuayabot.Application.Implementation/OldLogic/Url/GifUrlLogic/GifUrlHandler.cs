//using System;
//using System.Net;
//using System.Threading;
//using System.Threading.Tasks;
//using ElGuayabot.Application.Contract.Client;
//using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
//using MediatR;
//using Microsoft.Extensions.Logging;
//
//namespace ElGuayabot.Application.Implementation.Logic.Url.GifUrlLogic
//{
//    public class GifUrlHandler : AbstractHandler<GifUrlRequest>
//    {
//        public GifUrlHandler(IBotClient bot, ILogger<AbstractHandler<GifUrlRequest>> logger) : base(bot, logger)
//        {
//        }
//
//        public override async Task<Unit> Handle(GifUrlRequest request, CancellationToken cancellationToken)
//        {
//            var message = request.Message;
//            
//            string url = message.Text;
//
//            try
//            {
//                if (CheckWebsite(url))
//                {
//                    await Bot.SendDocumentAsync(
//                        chatId: message.Chat.Id,
//                        document: url,
//                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
//                        replyToMessageId: message.MessageId,
//                        cancellationToken: cancellationToken);
//                }
//
//            }
//            catch (Exception e)
//            {
//                Logger.LogError("Error handling gif url", e);
//            }
//
//            return Unit.Value;
//        }
//
//        private bool CheckWebsite(string url)
//        {
//            //TODO: refactor this. Try-Catch should not be used as conditional.
//            try
//            {
//                WebClient wc = new WebClient();
//                string htmlSource = wc.DownloadString(url);
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }
//    }
//}
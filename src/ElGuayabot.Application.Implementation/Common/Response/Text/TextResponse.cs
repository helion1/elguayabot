using ElGuayabot.Application.Contract.Common.Responses;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Common.Response.Text
{
    public class TextResponse: Request<Result>, IResponse
    {
        public string Text { get; set; }
        public ParseMode ParseMode { get; set; }
        public int MessageId { get; set; }


        public TextResponse(string text, ParseMode parseMode = ParseMode.Markdown, int messageId = 0)
        {
            Text = text;
            ParseMode = parseMode;
            MessageId = messageId;
        }
    }
}
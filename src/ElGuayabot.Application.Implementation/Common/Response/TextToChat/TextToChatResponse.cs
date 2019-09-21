using ElGuayabot.Application.Contract.Common.Responses;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Common.Response.TextToChat
{
    public class TextToChatResponse : Request<Result>, IResponse
    {
        public string Text { get; set; }
        public long ChatId { get; set; }
        public ParseMode ParseMode { get; set; }

        public TextToChatResponse(string text, long chatId, ParseMode mode)
        {
            Text = text;
            ChatId = chatId;
            ParseMode = mode;
        }
    }
}
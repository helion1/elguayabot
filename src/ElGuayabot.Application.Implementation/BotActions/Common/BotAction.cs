using ElGuayabot.Application.Contract.BotActions.Common;
using ElGuayabot.Application.Contract.Common.Context;
using Telegram.Bot.Types;
using TheWeatherman.Common.Request;
using TheWeatherman.Common.Result;

namespace ElGuayaBot.Application.Implementation.BotActions.Common
{
    public abstract class BotAction : Request<Result>, IBotAction
    {
        public int MessageId { get; set; }
        public Chat Chat { get; set; }
        public User From { get; set; }
        public string Text { get; set; }
        protected BotAction(int messageId, Chat chat, User from, string text)
        {
            MessageId = messageId;
            Chat = chat;
            From = from;
            Text = text;
        }

        protected BotAction(IBotContext botContext)
        {
            MessageId = botContext.Message?.MessageId ?? 0;
            Chat = botContext.Chat;
            From = botContext.User;
            Text = botContext.Message?.Text;
        }
        
        public abstract bool CanHandle(string condition);
    }
}
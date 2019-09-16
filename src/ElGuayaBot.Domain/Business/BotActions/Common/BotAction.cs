using System;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Entity;

namespace ElGuayabot.Domain.Business.BotActions.Common
{
    public class BotAction : Request<Result>
    {
        public int MessageId { get; set; }
        public Chat Chat { get; set; }
        public User From { get; set; }
        public string Text { get; set; }
        public Uri[] Urls { get; set; }
        public string[] Mentions { get; set; }
    }
}
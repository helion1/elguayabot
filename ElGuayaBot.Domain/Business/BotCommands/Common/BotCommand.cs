using System;
using ElGuayaBot.Common.Request;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Entity;

namespace ElGuayaBot.Domain.Business.BotCommands.Common
{
    public class BotCommand : Request<Result>
    {
        public int MessageId { get; set; }
        public Chat Chat { get; set; }
        public User From { get; set; }
        public string Text { get; set; }
        public Uri[] Urls { get; set; }
        public string[] Mentions { get; set; }
    }
}
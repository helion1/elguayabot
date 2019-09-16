using System;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Entity;
using MediatR;

namespace ElGuayabot.Domain.Business.Messages
{
    public class MessageCommand : Request<Result>
    {
        public int Id { get; set; }
        public MessageType Type { get; set; }
        public Chat Chat { get; set; }
        public User From { get; set; }
        public string Text { get; set; }
        public string Command { get; set; }
        public Uri[] Urls { get; set; }
        public string[] Mentions { get; set; }
    }

    public enum MessageType
    {  
        Other,
        Text,
        Photo,
        Audio,
        Video,
        Voice,
        Document,
        Sticker,
        Location
    }
}
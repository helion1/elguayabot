using System;

namespace ElGuayaBot.Domain.Entity
{
    public class Chat
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime FirstSeen { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace ElGuayaBot.Domain.Entity
{
    public class Chat
    {
        public Chat()
        {
            Users = new HashSet<ChatUser>();
        }
        
        public long Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime FirstSeen { get; set; }
        
        public ICollection<ChatUser> Users { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace ElGuayaBot.Domain.Entity
{
    public class User
    {
        public User()
        {
            Chats = new HashSet<ChatUser>();
        }
        
        public int Id { get; set; }
        public bool IsBot { get; set; }
        public string LanguageCode { get; set; }
        public string Username { get; set; }
        public DateTime FirstSeen { get; set; }
        
        public ICollection<ChatUser> Chats { get; set; }
    }
}
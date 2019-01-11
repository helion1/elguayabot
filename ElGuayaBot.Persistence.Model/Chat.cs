using System;
using System.Collections.Generic;

namespace ElGuayaBot.Persistence.Model
{
    public partial class Chat
    {
        public Chat()
        {
            ChatUsers = new HashSet<ChatUser>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime FirstInteractionDate { get; set; }

        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}

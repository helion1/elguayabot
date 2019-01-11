using System;
using System.Collections.Generic;

namespace ElGuayaBot.Persistence.Model
{
    public partial class User
    {
        public User()
        {
            GroupUsers = new HashSet<ChatUser>();
        }

        public int Id { get; set; }
        public bool IsBot { get; set; }
        public string LanguageCode { get; set; }
        public string Username { get; set; }
        public DateTime FirstInteractionDate { get; set; }

        public ICollection<ChatUser> GroupUsers { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ElGuayaBot.Persistence.Model
{
    public partial class Group
    {
        public Group()
        {
            GroupUsers = new HashSet<GroupUser>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime FirstInteractionDate { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}

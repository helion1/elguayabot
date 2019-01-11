namespace ElGuayaBot.Persistence.Model
{
    public partial class GroupUser
    {
        public long GroupId { get; set; }
        public int UserId { get; set; }

        public Group Group { get; set; }
        public User User { get; set; }
    }
}

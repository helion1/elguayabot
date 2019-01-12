namespace ElGuayaBot.Persistence.Model
{
    public partial class ChatUser
    {
        public long ChatId { get; set; }
        public int UserId { get; set; }

        public Chat Chat { get; set; }
        public User User { get; set; }
    }
}

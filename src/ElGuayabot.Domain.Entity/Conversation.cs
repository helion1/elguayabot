namespace ElGuayabot.Domain.Entity
{
    public class Conversation
    {
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
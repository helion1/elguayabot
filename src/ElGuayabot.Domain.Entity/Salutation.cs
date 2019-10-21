using System;

namespace ElGuayabot.Domain.Entity
{
    public class Salutation
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
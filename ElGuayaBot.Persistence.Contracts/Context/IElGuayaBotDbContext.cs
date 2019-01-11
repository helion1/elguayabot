using ElGuayaBot.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace ElGuayaBot.Persistence.Contracts.Context
{
    public interface IElGuayaBotDbContext : IDbContext
    {
        DbSet<Chat> Chats { get; set; }
        
        DbSet<ChatUser> ChatUsers { get; set; }
        
        DbSet<User> Users { get; set; }
    }
}
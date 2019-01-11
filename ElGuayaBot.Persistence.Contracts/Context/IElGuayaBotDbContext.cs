using ElGuayaBot.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace ElGuayaBot.Persistence.Contracts.Context
{
    public interface IElGuayaBotDbContext : IDbContext
    {
        DbSet<Chat> Groups { get; set; }
        
        DbSet<ChatUser> GroupUsers { get; set; }
        
        DbSet<User> Users { get; set; }
    }
}
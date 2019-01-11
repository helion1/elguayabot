using ElGuayaBot.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace ElGuayaBot.Persistence.Contracts.Context
{
    public interface IElGuayaBotDbContext : IDbContext
    {
        DbSet<Group> Groups { get; set; }
        
        DbSet<GroupUser> GroupUsers { get; set; }
        
        DbSet<User> Users { get; set; }
    }
}
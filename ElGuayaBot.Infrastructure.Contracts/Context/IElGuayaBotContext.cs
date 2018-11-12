using ElGuayaBot.Infrastructure.Contracts.Model;
using Microsoft.EntityFrameworkCore;

namespace ElGuayaBot.Infrastructure.Contracts.Context
{
    public interface IElGuayaBotContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Group> Groups { get; set; }
    }
}
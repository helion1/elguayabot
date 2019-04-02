using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contracts.Context;

namespace ElGuayaBot.Persistence.Contracts.Repository
{
    public interface IChatUserRepository : IAbstractGenericRepository<IElGuayaBotDbContext, ChatUser>
    {
        
    }
}
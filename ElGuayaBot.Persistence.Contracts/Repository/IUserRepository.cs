using ElGuayaBot.Persistence.Contracts.Context;
using ElGuayaBot.Persistence.Model;

namespace ElGuayaBot.Persistence.Contracts.Repository
{
    public interface IUserRepository : IAbstractGenericRepository<IElGuayaBotDbContext, User>
    {
        
    }
}
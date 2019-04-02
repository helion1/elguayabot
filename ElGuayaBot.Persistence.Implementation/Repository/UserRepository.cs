using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class UserRepository : AbstractGenericRepository<ElGuayaBotDbContext, User>, IUserRepository
    {
        public UserRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
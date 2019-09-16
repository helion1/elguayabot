using ElGuayabot.Domain.Entity;
using ElGuayabot.Persistence.Contract.Repository;
using ElGuayabot.Persistence.Implementation.Context;

namespace ElGuayabot.Persistence.Implementation.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
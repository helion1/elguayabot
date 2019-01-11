using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;
using ElGuayaBot.Persistence.Model;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class GroupUserRepository : AbstractGenericRepository<ElGuayaBotDbContext, GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
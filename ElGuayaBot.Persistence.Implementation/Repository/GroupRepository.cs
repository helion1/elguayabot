using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;
using ElGuayaBot.Persistence.Model;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class GroupRepository : AbstractGenericRepository<ElGuayaBotDbContext, Chat>, IGroupRepository
    {
        public GroupRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
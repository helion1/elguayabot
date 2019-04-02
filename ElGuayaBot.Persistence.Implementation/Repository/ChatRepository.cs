using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class ChatRepository : AbstractGenericRepository<ElGuayaBotDbContext, Chat>, IChatRepository
    {
        public ChatRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
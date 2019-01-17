using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;
using ElGuayaBot.Persistence.Model;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class ChatRepository : AbstractGenericRepository<ElGuayaBotDbContext, Chat>, IChatRepository
    {
        public ChatRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
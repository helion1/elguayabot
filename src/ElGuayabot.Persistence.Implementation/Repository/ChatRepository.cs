using ElGuayabot.Domain.Entity;
using ElGuayabot.Persistence.Contract.Repository;
using ElGuayabot.Persistence.Implementation.Context;

namespace ElGuayabot.Persistence.Implementation.Repository
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
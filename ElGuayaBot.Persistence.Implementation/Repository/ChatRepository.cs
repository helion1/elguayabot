using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contract.Repository;
using ElGuayaBot.Persistence.Implementation.Context;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
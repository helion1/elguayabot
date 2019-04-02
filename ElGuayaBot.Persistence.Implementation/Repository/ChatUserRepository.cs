using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class ChatUserRepository : AbstractGenericRepository<ElGuayaBotDbContext, ChatUser>, IChatUserRepository
    {
        public ChatUserRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
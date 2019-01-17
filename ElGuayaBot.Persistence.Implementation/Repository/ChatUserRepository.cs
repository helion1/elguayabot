using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;
using ElGuayaBot.Persistence.Model;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public class ChatUserRepository : AbstractGenericRepository<ElGuayaBotDbContext, ChatUser>, IChatUserRepository
    {
        public ChatUserRepository(ElGuayaBotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
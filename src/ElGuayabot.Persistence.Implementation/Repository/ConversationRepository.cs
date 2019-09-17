using ElGuayabot.Domain.Entity;
using ElGuayabot.Persistence.Contract.Repository;
using ElGuayabot.Persistence.Implementation.Context;
using Microsoft.EntityFrameworkCore;

namespace ElGuayabot.Persistence.Implementation.Repository
{
    public class ConversationRepository : GenericRepository<Conversation>, IConversationRepository
    {
        public ConversationRepository(ElGuayabotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
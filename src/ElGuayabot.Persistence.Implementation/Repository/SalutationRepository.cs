using ElGuayabot.Domain.Entity;
using ElGuayabot.Persistence.Contract.Repository;
using ElGuayabot.Persistence.Implementation.Context;

namespace ElGuayabot.Persistence.Implementation.Repository
{
    public class SalutationRepository : GenericRepository<Salutation>, ISalutationRepository
    {
        public SalutationRepository(ElGuayabotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
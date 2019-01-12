using System.Collections.Generic;
using System.Linq;
using ElGuayaBot.Persistence.Contracts.Context;

namespace ElGuayaBot.Persistence.Contracts.Repository
{
    public interface IAbstractGenericRepository<TC, TE> where TC : IDbContext where TE : class
    {
        IQueryable<TE> GetAll();
        
        TE GetById(object id);

        TE Insert(TE entity);
        
        TE Update(TE entityToUpdate);

        TE Delete(object id);
        
        TE Delete(TE entityToDelete);
    }
}
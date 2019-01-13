using System;
using System.Linq;
using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;
using Microsoft.EntityFrameworkCore;

namespace ElGuayaBot.Persistence.Implementation.Repository
{
    public abstract class AbstractGenericRepository<TC, TE> : IAbstractGenericRepository<TC, TE> where TC : ElGuayaBotDbContext where TE : class
    {
        protected readonly TC Context;
        
        protected readonly DbSet<TE> DbSet;

        protected AbstractGenericRepository(TC dbContext)
        {
            Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = dbContext.Set<TE>();
        }

        public virtual IQueryable<TE> GetAll()
        {
            return DbSet;
        }

        public virtual TE GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TE Insert(TE entity)
        {
            var entry = DbSet.Add(entity);
            
            return entry.Entity;
        }

        public virtual TE Update(TE entityToUpdate)
        {
            var entry = DbSet.Attach(entityToUpdate);
            
            Context.Entry(entityToUpdate).State = EntityState.Modified;

            return entry.Entity;
        }

        public virtual TE Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            
            return Delete(entityToDelete);
        }

        public virtual TE Delete(TE entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            
            var entry = DbSet.Remove(entityToDelete);

            return entry.Entity;
        }
    }
}
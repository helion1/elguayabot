using System;
using System.Threading.Tasks;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Contracts.Repository;
using ElGuayaBot.Persistence.Implementation.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ElGuayaBotDbContext Context;
        
        protected readonly ILogger<UnitOfWork> Logger;
        
        private bool _disposed;

        public IGroupRepository GroupRepository { get; set; }
        public IGroupUserRepository GroupUserRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(ElGuayaBotDbContext context, ILogger<UnitOfWork> logger, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository, IUserRepository userRepository)
        {
            Context = context;
            Logger = logger;
            GroupRepository = groupRepository;
            GroupUserRepository = groupUserRepository;
            UserRepository = userRepository;
        }

        public async Task SaveAsync()
        {
            try
            {
                await Context.SaveChangesAsync();

                Logger.LogInformation("database save operation finished correctly");
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Logger.LogError(exception, "database save operation failed ");

                throw;
            }
            catch (DbUpdateException exception)
            {
                Logger.LogError(exception, "database save operation failed ");

                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
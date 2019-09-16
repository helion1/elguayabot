using System;
using System.Threading.Tasks;
using ElGuayabot.Persistence.Contract;
using ElGuayabot.Persistence.Contract.Repository;
using ElGuayabot.Persistence.Implementation.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ElGuayaBotDbContext Context;
        protected readonly ILogger<UnitOfWork> Logger;
        
        private bool _disposed;

        public IChatRepository ChatRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(ElGuayaBotDbContext context, ILogger<UnitOfWork> logger, IChatRepository chatRepository, IUserRepository userRepository)
        {
            Context = context;
            Logger = logger;
            ChatRepository = chatRepository;
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
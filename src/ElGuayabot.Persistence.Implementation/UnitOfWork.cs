using System;
using System.Threading;
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
        protected readonly ElGuayabotDbContext Context;
        protected readonly ILogger<UnitOfWork> Logger;
        private bool _disposed;

        public IChatRepository ChatRepository { get; set; }
        public IConversationRepository ConversationRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ISalutationRepository SalutationRepository { get; set; }
        
        public UnitOfWork(ElGuayabotDbContext context, ILogger<UnitOfWork> logger, IChatRepository chatRepository, IConversationRepository conversationRepository, IUserRepository userRepository, ISalutationRepository salutationRepository)
        {
            Context = context;
            Logger = logger;
            ChatRepository = chatRepository;
            ConversationRepository = conversationRepository;
            UserRepository = userRepository;
            SalutationRepository = salutationRepository;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.SaveChangesAsync(cancellationToken);
                
                Logger.LogInformation("Database save operation finished correctly.");
            }
            catch (DbUpdateConcurrencyException e)
            {
                Logger.LogError(e, "Database save operation failed, concurrency related.");

                throw;
            }
            catch (DbUpdateException e)
            {
                Logger.LogError(e, "Database save operation failed.");

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
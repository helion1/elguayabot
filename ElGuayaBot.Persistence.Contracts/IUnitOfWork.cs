using System.Threading.Tasks;
using ElGuayaBot.Persistence.Contracts.Repository;

namespace ElGuayaBot.Persistence.Contracts
{
    public interface IUnitOfWork
    {
        IChatRepository ChatRepository { get; set; }
        
        IChatUserRepository ChatUserRepository { get; set; }
        
        IUserRepository UserRepository { get; set; }
        
        Task SaveAsync();
    }
}
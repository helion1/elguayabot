using System.Threading.Tasks;
using ElGuayaBot.Persistence.Contracts.Repository;

namespace ElGuayaBot.Persistence.Contracts
{
    public interface IUnitOfWork
    {
        IGroupRepository ChatRepository { get; set; }
        
        IGroupUserRepository ChatUserRepository { get; set; }
        
        IUserRepository UserRepository { get; set; }
        
        Task SaveAsync();
    }
}
using System.Threading.Tasks;
using ElGuayaBot.Persistence.Contracts.Repository;

namespace ElGuayaBot.Persistence.Contracts
{
    public interface IUnitOfWork
    {
        IGroupRepository GroupRepository { get; set; }
        
        IGroupUserRepository GroupUserRepository { get; set; }
        
        IUserRepository UserRepository { get; set; }
        
        Task SaveAsync();
    }
}
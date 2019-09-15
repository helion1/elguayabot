using System.Threading.Tasks;
using ElGuayaBot.Persistence.Contract.Repository;

namespace ElGuayaBot.Persistence.Contract
{
    public interface IUnitOfWork
    {
        IChatRepository ChatRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        
        Task SaveAsync();
    }
}
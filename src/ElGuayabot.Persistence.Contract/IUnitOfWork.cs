using System.Threading.Tasks;
using ElGuayabot.Persistence.Contract.Repository;

namespace ElGuayabot.Persistence.Contract
{
    public interface IUnitOfWork
    {
        IChatRepository ChatRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        
        Task SaveAsync();
    }
}
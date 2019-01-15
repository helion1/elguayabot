using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Persistence.Model;

namespace ElGuayaBot.Application.Contracts.Service
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        bool IsPersisted(int fromId);
        
        Task AddAsync(int fromId, string fromUsername, bool fromIsBot, string fromLanguageCode);
    }
}
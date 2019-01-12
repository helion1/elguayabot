using System.Threading.Tasks;

namespace ElGuayaBot.Application.Contracts.Service
{
    public interface IUserService
    {
        bool IsPersisted(int fromId);
        
        Task AddAsync(int fromId, string fromUsername, bool fromIsBot, string fromLanguageCode);
    }
}
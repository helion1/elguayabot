using System.Threading.Tasks;

namespace ElGuayaBot.Application.Contracts.Service
{
    public interface IChatUserService
    {
        bool IsPersisted(long chatId, int fromId);
        
        Task AddAsync(long chatId, int fromId);
    }
}
using System.Threading.Tasks;

namespace ElGuayaBot.Application.Contract.Service
{
    public interface IChatUserService
    {
        bool IsPersisted(long chatId, int fromId);
        
        Task AddAsync(long chatId, int fromId);
    }
}
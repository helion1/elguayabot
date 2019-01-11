using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Contracts.Service
{
    public interface IChatService
    {
        bool IsPersisted(long chatId);
        
        Task AddAsync(long chatId, ChatType chatType, string chatTitle);
    }
}
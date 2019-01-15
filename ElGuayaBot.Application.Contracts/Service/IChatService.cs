using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Persistence.Model;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Contracts.Service
{
    public interface IChatService
    {
        IQueryable<Chat> GetAllChats();
        
        IQueryable<Chat> GetGroupChats();
        
        IQueryable<Chat> GetSupergroupChats();

        IQueryable<Chat> GetPrivateChats();
        
        IQueryable<Chat> GetGroupAndSupergroupChats();

        bool IsPersisted(long chatId);
        
        Task AddAsync(long chatId, ChatType chatType, string chatTitle);
        
        Task UpdateTitleForChat(long chatId, string messageNewChatTitle);
        
    }
}
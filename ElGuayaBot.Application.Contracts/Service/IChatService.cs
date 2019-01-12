using System.Collections.Generic;
using System.Threading.Tasks;
using ElGuayaBot.Persistence.Model;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Contracts.Service
{
    public interface IChatService
    {
        bool IsPersisted(long chatId);
        
        Task AddAsync(long chatId, ChatType chatType, string chatTitle);

        IEnumerable<Chat> GetGroupAndSupergroupChats();
        Task UpdateTitleForChat(long chatId, string messageNewChatTitle);
    }
}
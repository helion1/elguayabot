using System;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Model;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Service
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<ChatService> _logger;

        public ChatService(IUnitOfWork unitOfWork, ILogger<ChatService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IQueryable<Chat> GetAllChats()
        {
            return _unitOfWork.ChatRepository.GetAll();
        }

        public IQueryable<Chat> GetGroupChats()
        {
            return _unitOfWork.ChatRepository.GetAll().Where(ch => ch.Type == "Group");
        }

        public IQueryable<Chat> GetSupergroupChats()
        {
            return _unitOfWork.ChatRepository.GetAll().Where(ch => ch.Type == "Supergroup");
        }

        public IQueryable<Chat> GetPrivateChats()
        {
            return _unitOfWork.ChatRepository.GetAll().Where(ch => ch.Type == "Private");
        }
        
        public bool IsPersisted(long chatId)
        {
            try
            {
                var chat = _unitOfWork.ChatRepository.GetById(chatId);

                return chat != null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error searching for chat with id: {chatId}", e);

                return false;
            }
        }

        public async Task AddAsync(long chatId, ChatType chatType, string chatTitle)
        {
            try
            {
                _unitOfWork.ChatRepository.Insert(new Chat
                {
                    Id = chatId,
                    Type = chatType.ToString(),
                    Title = chatTitle,
                    FirstInteractionDate = DateTime.Now
                });
                    
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error persisting chat with id: {chatId}", e);
            }
        }

        public IQueryable<Chat> GetGroupAndSupergroupChats()
        {
            return _unitOfWork.ChatRepository.GetAll().Where(ch => ch.Type == "Group" || ch.Type == "Supergroup");
        }

        public async Task UpdateTitleForChat(long chatId, string newChatTitle)
        {
            try
            {
                var chat = _unitOfWork.ChatRepository.GetById(chatId);

                chat.Title = newChatTitle;

                _unitOfWork.ChatRepository.Update(chat);
                
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error updating title for chat with id: {chatId}", e);
            }
        }
    }
}
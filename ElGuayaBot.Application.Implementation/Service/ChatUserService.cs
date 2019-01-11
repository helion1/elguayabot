using System;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Model;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Service
{
    public class ChatUserService: IChatUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<ChatUserService> _logger;

        public ChatUserService(IUnitOfWork unitOfWork, ILogger<ChatUserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        
        public bool IsPersisted(long chatId, int fromId)
        {
            try
            {
                var chatUser = _unitOfWork.ChatUserRepository.GetAll().FirstOrDefault(cu => cu.ChatId == chatId && cu.UserId == fromId);

                return chatUser != null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error searching for Chat User relationship with chat id: {chatId}, and user id: {fromId}", e);

                return false;
            }
        }

        public async Task AddAsync(long chatId, int fromId)
        {
            try
            {
                _unitOfWork.ChatUserRepository.Insert(new ChatUser
                {
                    ChatId = chatId,
                    UserId = fromId
                });
                    
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error persisting Chat User relationship with chat id: {chatId}, and user id: {fromId}", e);
            }        
        }
    }
}
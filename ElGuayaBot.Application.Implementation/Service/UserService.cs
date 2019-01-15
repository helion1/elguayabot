using System;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Model;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Service
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IQueryable<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public bool IsPersisted(int fromId)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetById(fromId);

                return user != null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error searching for user with id: {fromId}", e);

                return false;
            }
        }

        public async Task AddAsync(int fromId, string fromUsername, bool fromIsBot, string fromLanguageCode)
        {
            if (fromLanguageCode == null)
            {
                fromLanguageCode = "en";
            }
            
            try
            {
                _unitOfWork.UserRepository.Insert(new User
                {
                    Id = fromId,
                    Username = fromUsername,
                    LanguageCode = fromLanguageCode,
                    IsBot = fromIsBot,
                    FirstInteractionDate = DateTime.Now
                });
                    
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error persisting user with id: {fromId}", e);
            }
        }
    }
}
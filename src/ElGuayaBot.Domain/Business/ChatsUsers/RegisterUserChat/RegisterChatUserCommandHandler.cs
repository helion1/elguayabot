using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.ChatsUsers.RegisterUserChat
{
    public class RegisterChatUserCommandHandler : Common.Request.RequestHandler<RegisterChatUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public RegisterChatUserCommandHandler(ILogger<Common.Request.RequestHandler<RegisterChatUserCommand, Result>> logger, IMediator mediatR, 
            IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(RegisterChatUserCommand request, CancellationToken cancellationToken)
        {
            var chat = await _unitOfWork.ChatRepository.FindById(request.Chat.Id);
            var user = await _unitOfWork.UserRepository.FindBy(u => u.Id == request.User.Id, u => u.Chats);

            if (chat == null)
            {
                chat = await _unitOfWork.ChatRepository.Insert(request.Chat);
            }

            if (user == null)
            {
                user = await _unitOfWork.UserRepository.Insert(request.User);
            }

            // If the user already exists and has a chat registered with that Id.
            if (user.Chats.Any(chatUser => chatUser.ChatId == chat.Id))
            {
                return Result.Success();
            }
            
            // If not, then create it.
            user.Chats.Add(new ChatUser
            {
                User = user,
                Chat = chat
            });

            await _unitOfWork.SaveAsync();
            
            return Result.Success();
        }
    }
}
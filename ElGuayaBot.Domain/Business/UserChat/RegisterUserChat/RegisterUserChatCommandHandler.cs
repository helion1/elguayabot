using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Entity;
using ElGuayaBot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.UserChat.RegisterUserChat
{
    public class RegisterUserChatCommandHandler : Common.Request.RequestHandler<RegisterUserChatCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public RegisterUserChatCommandHandler(ILogger<Common.Request.RequestHandler<RegisterUserChatCommand, Result>> logger, IMediator mediatR, 
            IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(RegisterUserChatCommand request, CancellationToken cancellationToken)
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
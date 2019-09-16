using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Business.ChatsUsers.DeleteUserFromChat
{
    public class DeleteChatUserCommandHandler : Common.Request.RequestHandler<DeleteChatUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteChatUserCommandHandler(ILogger<Common.Request.RequestHandler<DeleteChatUserCommand, Result>> logger, IMediator mediatR,
            IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(DeleteChatUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindBy(u => u.Id == request.UserId, u => u.Chats);
            
            if (user == null)
            {
                return Result.Fail("not_found", new List<string> {"requested user was not found"});
            }

            var chatUser = user.Chats.Single(cu => cu.ChatId == request.ChatId);

            user.Chats.Remove(chatUser);

            _unitOfWork.UserRepository.Update(user);

            await _unitOfWork.SaveAsync();
            
            return Result.Success();
        }
    }
}
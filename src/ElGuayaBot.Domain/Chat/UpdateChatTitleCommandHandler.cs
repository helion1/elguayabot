using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Chat
{
    public class UpdateChatTitleCommandHandler : CommonHandler<UpdateChatTitleCommand, Result>
    {
        protected readonly IUnitOfWork UnitOfWork;

        public UpdateChatTitleCommandHandler(ILogger<CommonHandler<UpdateChatTitleCommand, Result>> logger, IMediator mediatR, IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            UnitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(UpdateChatTitleCommand request, CancellationToken cancellationToken)
        {
            var chat = await UnitOfWork.ChatRepository.FindById(request.ChatId);

            if (chat == null) return Result.NotFound();

            chat.Title = request.Title;

            return Result.Success();;
        }
    }
}
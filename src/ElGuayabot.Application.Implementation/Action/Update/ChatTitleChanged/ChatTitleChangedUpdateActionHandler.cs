using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatTitleChanged
{
    public class ChatTitleChangedUpdateActionHandler : CommonHandler<ChatTitleChangedUpdateAction, Result>
    {
        protected readonly IUnitOfWork UnitOfWork;

        public ChatTitleChangedUpdateActionHandler(ILogger<CommonHandler<ChatTitleChangedUpdateAction, Result>> logger, IMediator mediatR, IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            UnitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(ChatTitleChangedUpdateAction request, CancellationToken cancellationToken)
        {
            await MediatR.Send(request.MapToUpdateChatTitleCommand());
            
            return await MediatR.Send(new TextResponse("¡Vergación! 😱 El nuevo título del chat esta bien ahuevonado!"), cancellationToken);
        }
    }
}
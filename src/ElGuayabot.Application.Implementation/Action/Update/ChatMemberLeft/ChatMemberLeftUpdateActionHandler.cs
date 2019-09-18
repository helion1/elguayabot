using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberLeft
{
    public class ChatMemberLeftUpdateActionHandler : CommonHandler<ChatMemberLeftUpdateAction, Result>
    {
        protected readonly IUnitOfWork UnitOfWork;

        public ChatMemberLeftUpdateActionHandler(ILogger<CommonHandler<ChatMemberLeftUpdateAction, Result>> logger, IMediator mediatR, IUnitOfWork unitOfWork) : base(logger, mediatR)
        {
            UnitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(ChatMemberLeftUpdateAction request, CancellationToken cancellationToken)
        {
            var deleteConversationResult = await MediatR.Send(request.MapToDeleteConversationCommand(), cancellationToken);

            if (!deleteConversationResult.Succeeded)
            {
                //TODO log error
            }

            var message = $"@{request.Update.Message.LeftChatMember.Username} murió combatiendo el imperialismo.";
            
            return await MediatR.Send(new TextResponse(message), cancellationToken);

            
            //
        }
    }
}
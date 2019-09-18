using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberAdded
{
    public class ChatMemberAddedUpdateActionHandler : CommonHandler<ChatMemberAddedUpdateAction, Result>
    {
        public ChatMemberAddedUpdateActionHandler(ILogger<CommonHandler<ChatMemberAddedUpdateAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override Task<Result> Handle(ChatMemberAddedUpdateAction request, CancellationToken cancellationToken)
        {
            var result = MediatR.Publish(request.MapToAddConversationCommand());
        }
    }
}
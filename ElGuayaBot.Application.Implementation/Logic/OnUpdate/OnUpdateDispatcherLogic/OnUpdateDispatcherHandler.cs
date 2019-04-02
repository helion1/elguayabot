using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayaBot.Application.Implementation.Logic.OnUpdate.IsLeftChatMemberLogic;
using ElGuayaBot.Application.Implementation.Logic.OnUpdate.IsNewChatMembersLogic;
using ElGuayaBot.Application.Implementation.Logic.OnUpdate.IsNewChatTitleLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.OnUpdate.OnUpdateDispatcherLogic
{
    public class OnUpdateDispatcherHandler : AbstractHandler<OnUpdateDispatcherRequest>
    {
        private readonly IMediator _mediatR;

        public OnUpdateDispatcherHandler(IBotClient bot, ILogger<AbstractHandler<OnUpdateDispatcherRequest>> logger, IMediator mediatR) : base(bot, logger)
        {
            _mediatR = mediatR;
        }

        public override async Task<Unit> Handle(OnUpdateDispatcherRequest request, CancellationToken cancellationToken)
        {
            var update = request.Update;
            
            var message = update.Message;

            if (message?.NewChatMembers != null)
            {
                await _mediatR.Send(new IsNewChatMembersRequest {Update = update}, cancellationToken);
            }
            else if (message?.LeftChatMember != null)
            {
                await _mediatR.Send(new IsLeftChatMemberRequest {Update = update}, cancellationToken);
            } else if (message?.NewChatTitle != null)
            {
                await _mediatR.Send(new IsNewChatTitleRequest {Update = update}, cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Update.ChatMemberAdded
{
    public class ChatMemberAddedUpdateActionHandler : CommonHandler<ChatMemberAddedUpdateAction, Result>
    {
        public ChatMemberAddedUpdateActionHandler(ILogger<CommonHandler<ChatMemberAddedUpdateAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ChatMemberAddedUpdateAction request, CancellationToken cancellationToken)
        {
            var newUsers = request.Update.Message.NewChatMembers.ToList();

            var message = "Bienvenido a la noble causa del bolivarismo.";

            if (newUsers.Count == 1)
            {
                message = $"Bienvenido @{newUsers.First().Username} a la noble causa del bolivarismo.";
            }
            else if (newUsers.Count > 1)
            {
                //TODO: get all usernames
                message = $"Bienvenidos todos a la noble causa del bolivarismo.";
            }

            return await MediatR.Send(new TextResponse(message));
        }
    }
}
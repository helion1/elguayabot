using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Chat.FindAllGroupChats;
using ElGuayabot.Domain.Chat.FindAllPrivateChats;
using ElGuayabot.Domain.Chat.FindAllSuperGroupChats;
using ElGuayabot.Domain.Entity;
using ElGuayabot.Domain.User.FindAllUsers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Command.Stats
{
    public class StatsCommandActionHandler : CommonHandler<StatsCommandAction, Result>
    {
        public StatsCommandActionHandler(ILogger<CommonHandler<StatsCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public async override Task<Result> Handle(StatsCommandAction request, CancellationToken cancellationToken)
        {
            if (!request.From.IsAdmin || request.Chat.Type != Chat.ChatType.Private)
            {
                //TODO: send message mocking the user.
            }

            var groupChatsResult = await MediatR.Send(new FindAllGroupChatsQuery());
            var superGroupChatsResult = await MediatR.Send(new FindAllSuperGroupChatsQuery());
            var privateChatsResult = await MediatR.Send(new FindAllPrivateChatsQuery());
            var usersResult = await MediatR.Send(new FindAllUsersQuery());

            if (!groupChatsResult.Succeeded || !superGroupChatsResult.Succeeded || !privateChatsResult.Succeeded || !usersResult.Succeeded)
            {
                //TODO error!
            }
            
            var sb = new StringBuilder();
            sb.AppendLine("<b>ElGuayaBot</b> stats & Info:");
            sb.AppendLine();
            sb.AppendLine($"👱‍♂️ {usersResult.Value.Count()} <i>users</i>");
            sb.AppendLine($"👬 {privateChatsResult.Value.Count()} <i>private</i> chats");
            sb.AppendLine($"👨‍👨‍👦 {groupChatsResult.Value.Count()} <i>group</i> chats");
            sb.AppendLine($"👨‍👨‍👦‍👦️ {superGroupChatsResult.Value.Count()} <i>supergroups</i> chats");
            
            return await MediatR.Send(new TextResponse(sb.ToString()));

        }
    }
}
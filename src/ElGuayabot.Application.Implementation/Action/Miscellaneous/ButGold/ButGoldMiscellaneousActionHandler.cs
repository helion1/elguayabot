using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.ButGold
{
    public class ButGoldMiscellaneousActionHandler : CommonHandler<ButGoldMiscellaneousAction, Result>
    {
        public ButGoldMiscellaneousActionHandler(ILogger<CommonHandler<ButGoldMiscellaneousAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ButGoldMiscellaneousAction request, CancellationToken cancellationToken)
        {
            return await MediatR.Send(new TextResponse("but (<b>g</b>)old", ParseMode.Html), cancellationToken);
        }
    }
}
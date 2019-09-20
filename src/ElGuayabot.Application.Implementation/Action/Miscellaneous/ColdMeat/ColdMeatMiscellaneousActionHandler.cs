using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.ColdMeat
{
    public class ColdMeatMiscellaneousActionHandler : CommonHandler<ColdMeatMiscellaneousAction, Result>
    {
        public ColdMeatMiscellaneousActionHandler(ILogger<CommonHandler<ColdMeatMiscellaneousAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ColdMeatMiscellaneousAction request, CancellationToken cancellationToken)
        {
            return await MediatR.Send(new TextResponse("well here is cold meat.", ParseMode.Markdown, request.MessageId));
        }
    }
}
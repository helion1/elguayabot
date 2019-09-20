using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Command.About
{
    public class AboutCommandActionHandler : CommonHandler<AboutCommandAction, Result>
    {
        public AboutCommandActionHandler(ILogger<CommonHandler<AboutCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }
        
        public override async Task<Result> Handle(AboutCommandAction request, CancellationToken cancellationToken)
        {
            const string aboutText = "*ElGuayaBot*, made with humor and code by [Lucas](https://github.com/elementh) and [Daniel](https://github.com/Zabrios) for our friend [Jose](https://github.com/ElGuayaba)";

            return await MediatR.Send(new TextResponse(aboutText, ParseMode.Markdown));
        }

    }
}
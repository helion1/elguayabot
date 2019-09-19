using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Document;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.GifUrlDownload
{
    public class GifUrlDownloadMiscellaneousActionHandler : CommonHandler<GifUrlDownloadMiscellaneousAction, Result>
    {
        public GifUrlDownloadMiscellaneousActionHandler(ILogger<CommonHandler<GifUrlDownloadMiscellaneousAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(GifUrlDownloadMiscellaneousAction request, CancellationToken cancellationToken)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadString(request.Text);

                return await MediatR.Send(new DocumentResponse(request.Text, request.MessageId), cancellationToken);
            }
            catch (Exception)
            {
                return await MediatR.Send(new TextResponse(
                    "El régimen me ha cortado el acceso a internet y no puedo encontrar el maldito gif. ¡Reinténtelo camarada!",
                    ParseMode.Html, request.MessageId));
            }
        }
    }
}
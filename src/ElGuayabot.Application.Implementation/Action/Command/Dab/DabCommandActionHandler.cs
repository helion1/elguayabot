using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Photo;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Command.Dab
{
    public class DabCommandActionHandler : CommonHandler<DabCommandAction, Result>
    {
        protected readonly IGifSearchService GifSearchService;

        public DabCommandActionHandler(ILogger<CommonHandler<DabCommandAction, Result>> logger, IMediator mediatR, IGifSearchService gifSearchService) : base(logger, mediatR)
        {
            GifSearchService = gifSearchService;
        }

        public override async Task<Result> Handle(DabCommandAction request, CancellationToken cancellationToken)
        {
            var gifResult = await GifSearchService.GetRandomGif("dab");

            if (!gifResult.Succeeded)
            {
                return await MediatR.Send(new TextResponse(
                    "El régimen me ha cortado el acceso a internet y no puedo encontrar ningún <i>dab</i> ¡Reinténtelo camarada!",
                    ParseMode.Html));
            }

            return await MediatR.Send(new PhotoResponse(gifResult.Value), cancellationToken);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Photo;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Helper;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Command.Comandante
{
    public class ComandanteCommandActionHandler : CommonHandler<ComandanteCommandAction, Result>
    {
        protected readonly IImageSearchService ImageSearchService;
        
        public ComandanteCommandActionHandler(ILogger<CommonHandler<ComandanteCommandAction, Result>> logger, IMediator mediatR, IImageSearchService imageSearchService) : base(logger, mediatR)
        {
            ImageSearchService = imageSearchService;
        }

        public override async Task<Result> Handle(ComandanteCommandAction request, CancellationToken cancellationToken)
        {
           var topics = new[] { "nicolas maduro", "hugo chavez", "venezuela flag" };

           var r = RandomProvider.GetThreadRandom().Next(topics.Length);

           var luckyTopic = topics[r];
           
           var imageResult = await ImageSearchService.GetRandomUrl(luckyTopic);

           if (!imageResult.Succeeded)
           {
               return await MediatR.Send(new TextResponse("Camarada, no he encontrado al comandante. ¡Vuelve a intentarlo!"));
           }

           return await MediatR.Send(new PhotoResponse(imageResult.Value, "Hasta la victoria, siempre!"));
        }
    }
}
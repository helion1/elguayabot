using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayaBot.Application.Implementation.Logic.Url.GifUrlLogic;
using ElGuayaBot.Application.Implementation.Logic.Url.SpotifyAlbumLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.IsUrlDispatcherLogic
{
    public class IsUrlDispatcherHandler : AbstractHandler<IsUrlDispatcherRequest>
    {
        private readonly IMediator _mediatR;

        public IsUrlDispatcherHandler(IBotClient bot, ILogger<AbstractHandler<IsUrlDispatcherRequest>> logger, IMediator mediatR) : base(bot, logger)
        {
            _mediatR = mediatR;
        }

        public override async Task<Unit> Handle(IsUrlDispatcherRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            foreach (var entity in message.Entities.Where(entity => entity.Type == MessageEntityType.Url))
            {
                var url = message.Text.Substring(entity.Offset, entity.Length).ToLower();

                if (url.Contains("spotify.com/album"))
                {
                    await _mediatR.Send(new SpotifyAlbumRequest {Message = message}, cancellationToken);
                }
                else if (url.Contains(".gif"))
                {
                    await _mediatR.Send(new GifUrlRequest {Message = message}, cancellationToken);
                }

            }

            return Unit.Value;
        }
    }
}
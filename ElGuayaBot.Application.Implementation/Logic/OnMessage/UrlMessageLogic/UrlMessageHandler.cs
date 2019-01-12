using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayaBot.Application.Implementation.Logic.Url.GifUrlLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.UrlMessageLogic
{
    public class UrlMessageHandler : AbstractHandler<UrlMessageRequest>
    {
        private readonly IMediator _mediatR;

        public UrlMessageHandler(IBotClient bot, ILogger<AbstractHandler<UrlMessageRequest>> logger, IMediator mediatR) : base(bot, logger)
        {
            _mediatR = mediatR;
        }

        public override async Task<Unit> Handle(UrlMessageRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            foreach (var entity in message.Entities.Where(entity => entity.Type == MessageEntityType.Url))
            {
                var url = message.Text.Substring(entity.Offset, entity.Length).ToLower();
                
                if (url.Contains(".gif"))
                {
                    await _mediatR.Send(new GifUrlRequest {Message = message}, cancellationToken);
                }

            }

            return Unit.Value;
        }
    }
}
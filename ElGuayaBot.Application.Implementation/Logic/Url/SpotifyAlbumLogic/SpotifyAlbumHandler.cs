using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayaBot.Infrastructure.Contracts.Service;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Url.SpotifyAlbumLogic
{
    public class SpotifyAlbumHandler : AbstractHandler<SpotifyAlbumRequest>
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyAlbumHandler(IBotClient bot, ILogger<AbstractHandler<SpotifyAlbumRequest>> logger, ISpotifyService spotifyService) : base(bot, logger)
        {
            _spotifyService = spotifyService;
        }

        public override async Task<Unit> Handle(SpotifyAlbumRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            var uri = new Uri(message.EntityValues.First(en => en.Contains("spotify")));

            var album = await _spotifyService.GetAlbumAsync(uri);
            
            return Unit.Value;
        }
    }
}
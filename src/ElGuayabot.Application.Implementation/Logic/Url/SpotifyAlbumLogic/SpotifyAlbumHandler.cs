using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
using ElGuayabot.Infrastructure.Contract.Dto.Spotify;
using ElGuayabot.Infrastructure.Contract.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Logic.Url.SpotifyAlbumLogic
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

            var response = GenerateResponse(album);

            try
            {
                await Bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: album.ImageUrl,
                    caption: response,
                    parseMode: ParseMode.Html,
                    replyToMessageId: message.MessageId,
                    cancellationToken: cancellationToken);

            }
            catch (Exception e)
            {
                Logger.LogError("SPotify Album not handled", e);
            }
            
            return Unit.Value;
        }

        private string GenerateResponse(AlbumDto albumDto)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"💿 <b>Album</b>");
            sb.AppendLine();
            sb.AppendLine($"<i>Título</i> -  <a href=\"{albumDto.ExternalUri}\">{albumDto.Name}</a>");
            sb.AppendLine(value: $"<i>Artista(s)</i> - {String.Join(", ", albumDto.Artists.Select(dto => dto.Name))}");
            
            if (albumDto.Genres.Count != 0)
            {
                sb.AppendLine($"<i>Géneros</i> - {String.Join(", ", albumDto.Genres)}");
            }
            
            sb.AppendLine($"<i>Año</i> - {albumDto.ReleaseDate.Year}");
            
            sb.AppendLine();
            
            sb.AppendLine($"💿 <b>Tracks</b>");
            sb.AppendLine();

            var albums = albumDto.Tracks.Where(dto => dto.TrackNumber <= 15 && dto.DiscNumber == 1).Select(dto => $"<i>{dto.TrackNumber}</i> - {dto.Name} ({string.Format("{0:hh\\:mm}", TimeSpan.FromMilliseconds(dto.Duration))})");
            
            sb.AppendLine($"{string.Join("\n", albums)}");
            
            if (albumDto.Tracks.Count > 10)
            {
                sb.AppendLine($"<i>...más tracks en</i> <a href=\"{albumDto.ExternalUri}\">spotify</a>");
            }
            
            return sb.ToString();
        }
    }
}
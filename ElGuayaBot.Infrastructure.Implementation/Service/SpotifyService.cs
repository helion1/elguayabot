using System;
using System.Threading.Tasks;
using ElGuayaBot.Infrastructure.Contracts.Service;
using ElGuayaBot.Infrastructure.Dto.Spotify;
using ElGuayaBot.Infrastructure.Implementation.Client;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web;

namespace ElGuayaBot.Infrastructure.Implementation.Service
{
    public class SpotifyService : ISpotifyService
    {
        private ILogger<SpotifyService> _logger;
        private SpotifyWebAPI _client;

        public SpotifyService(ILogger<SpotifyService> logger, SpotifyClient spotifyClient)
        {
            _logger = logger;
            _client = spotifyClient.Client;
        }

        public async Task<Album> GetAlbumAsync(Uri uri)
        {
            var albumId = uri.Segments[2];
            
            var album = await _client.GetAlbumAsync(albumId);
            
            return new Album();
        }

        public Playlist GetPlaylist(Uri uri)
        {
            throw new System.NotImplementedException();
        }
    }
}
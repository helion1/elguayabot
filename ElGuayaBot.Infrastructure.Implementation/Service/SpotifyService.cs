using System;
using System.Threading.Tasks;
using ElGuayaBot.Infrastructure.Contracts.Dto.Spotify;
using ElGuayaBot.Infrastructure.Contracts.Service;
using ElGuayaBot.Infrastructure.Implementation.Client;
using ElGuayaBot.Infrastructure.Implementation.Mapping;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web;

namespace ElGuayaBot.Infrastructure.Implementation.Service
{
    public class SpotifyService : ISpotifyService
    {
        private ILogger<SpotifyService> _logger;
        private SpotifyClient _client;

        public SpotifyService(ILogger<SpotifyService> logger, SpotifyClient spotifyClient)
        {
            _logger = logger;
            _client = spotifyClient;
        }

        public async Task<AlbumDto> GetAlbumAsync(Uri uri)
        {
            var albumId = uri.Segments[2];
            
            var album = await _client.GetClient().GetAlbumAsync(albumId);

            return AlbumMapper.ToAlbumDto(album);
        }

        public PlaylistDto GetPlaylist(Uri uri)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Threading.Tasks;
using ElGuayaBot.Infrastructure.Dto.Spotify;

namespace ElGuayaBot.Infrastructure.Contracts.Service
{
    public interface ISpotifyService
    {
        Task<Album> GetAlbumAsync(Uri uri);

        Playlist GetPlaylist(Uri uri);
    }
}
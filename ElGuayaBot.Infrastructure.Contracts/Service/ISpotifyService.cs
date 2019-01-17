using System;
using System.Threading.Tasks;
using ElGuayaBot.Infrastructure.Dto.Spotify;

namespace ElGuayaBot.Infrastructure.Contracts.Service
{
    public interface ISpotifyService
    {
        Task<AlbumDto> GetAlbumAsync(Uri uri);

        PlaylistDto GetPlaylist(Uri uri);
    }
}
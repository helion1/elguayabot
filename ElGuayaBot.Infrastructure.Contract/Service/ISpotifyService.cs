using System;
using System.Threading.Tasks;
using ElGuayaBot.Infrastructure.Contract.Dto.Spotify;

namespace ElGuayaBot.Infrastructure.Contract.Service
{
    public interface ISpotifyService
    {
        Task<AlbumDto> GetAlbumAsync(Uri uri);

        PlaylistDto GetPlaylist(Uri uri);
    }
}
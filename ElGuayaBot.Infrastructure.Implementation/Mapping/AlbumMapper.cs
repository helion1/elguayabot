using System;
using System.Linq;
using ElGuayaBot.Infrastructure.Dto.Spotify;
using SpotifyAPI.Web.Models;

namespace ElGuayaBot.Infrastructure.Implementation.Mapping
{
    public static class AlbumMapper
    {
        public static AlbumDto ToAlbumDto(FullAlbum fullAlbum)
        {
            return new AlbumDto
            {
                Id = fullAlbum.Id,
                Name = fullAlbum.Name,
                Artists = ArtistMapper.ToArtistsDtoList(fullAlbum.Artists),
                Tracks = TrackMapper.ToTracksDtoList(fullAlbum.Tracks?.Items),
                Type = fullAlbum.Type,
                ExternalUri = fullAlbum.ExternalUrls?.FirstOrDefault().Value,
                Genres = fullAlbum.Genres,
                ImageUrl = fullAlbum.Images?.FirstOrDefault()?.Url,
                Popularity = fullAlbum.Popularity,
                ReleaseDate = DateTime.Parse(fullAlbum.ReleaseDate)
            };
        }
        
    }
}
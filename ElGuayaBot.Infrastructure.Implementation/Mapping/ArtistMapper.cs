using System.Collections.Generic;
using System.Linq;
using ElGuayaBot.Infrastructure.Dto.Spotify;
using Microsoft.EntityFrameworkCore.Internal;
using SpotifyAPI.Web.Models;

namespace ElGuayaBot.Infrastructure.Implementation.Mapping
{
    public static class ArtistMapper
    {
        public static ArtistDto ToArtistDto(SimpleArtist artist)
        {
            return new ArtistDto
            {
                Id = artist.Id,
                Name = artist.Name,
                ExternalUri = artist.ExternalUrls?.FirstOrDefault().Value
            };
        }

        public static List<ArtistDto> ToArtistsDtoList(List<SimpleArtist> artists)
        {
            var artistsDtoList = new List<ArtistDto>();
            
            foreach (var artist in artists)
            {
                artistsDtoList.Add(ToArtistDto(artist));
            }

            return artistsDtoList;
        }
    }
}
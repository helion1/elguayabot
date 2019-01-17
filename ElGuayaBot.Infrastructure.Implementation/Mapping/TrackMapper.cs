using System.Collections.Generic;
using System.Linq;
using ElGuayaBot.Infrastructure.Dto.Spotify;
using SpotifyAPI.Web.Models;

namespace ElGuayaBot.Infrastructure.Implementation.Mapping
{
    public static class TrackMapper
    {
        public static TrackDto ToTrackDto(SimpleTrack track)
        {
            return new TrackDto
            {
                Id = track.Id,
                Duration = track.DurationMs * 60,
                ExternalUri = track.ExternUrls?.FirstOrDefault().Value,
                Name = track.Name,
                Number = track.TrackNumber
            };
        }

        public static List<TrackDto> ToTracksDtoList(List<SimpleTrack> tracks)
        {
            var tracksDtoList = new List<TrackDto>();
            
            foreach (var track in tracks)
            {
                tracksDtoList.Add(ToTrackDto(track));
            }

            return tracksDtoList;
        }
    }
}
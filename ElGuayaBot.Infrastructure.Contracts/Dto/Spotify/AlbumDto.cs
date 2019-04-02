using System;
using System.Collections.Generic;

namespace ElGuayaBot.Infrastructure.Contracts.Dto.Spotify
{
    public class AlbumDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public List<ArtistDto> Artists { get; set; }
        
        public List<TrackDto> Tracks { get; set; }
        
        public string Type { get; set; }
        
        public string ExternalUri { get; set; }
        
        public string ImageUrl { get; set; }
        
        public int Popularity { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public List<string> Genres { get; set; }
    }
}
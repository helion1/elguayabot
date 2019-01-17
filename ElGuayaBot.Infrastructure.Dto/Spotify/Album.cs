using System;
using System.Collections.Generic;

namespace ElGuayaBot.Infrastructure.Dto.Spotify
{
    public class Album
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public List<Artist> Artists { get; set; }
        
        public List<Track> Tracks { get; set; }
        
        public string Type { get; set; }
        
        public string ExternalUri { get; set; }
        
        public string ImageUrl { get; set; }
        
        public int Popularity { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public List<string> Genres { get; set; }
    }
}
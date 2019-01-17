using System.Collections.Generic;

namespace ElGuayaBot.Infrastructure.Dto.Spotify
{
    public class Playlist
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string ExternalUri { get; set; }
        
        public List<Track> Tracks { get; set; }
    }
}
using System.Collections.Generic;

namespace ElGuayaBot.Infrastructure.Contracts.Dto.Spotify
{
    public class PlaylistDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string ExternalUri { get; set; }
        
        public List<TrackDto> Tracks { get; set; }
    }
}
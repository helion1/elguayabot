namespace ElGuayaBot.Infrastructure.Contract.Dto.Spotify
{
    public class TrackDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public int TrackNumber { get; set; }
        
        public int DiscNumber { get; set; }

        public int Duration { get; set; }

//        public int Popularity { get; set; }

        public string ExternalUri { get; set; }
    }
}
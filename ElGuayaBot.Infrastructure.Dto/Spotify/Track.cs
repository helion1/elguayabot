namespace ElGuayaBot.Infrastructure.Dto.Spotify
{
    public class Track
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Number { get; set; }

        public int Duration { get; set; }

        public int Popularity { get; set; }

        public string ExternalUri { get; set; }
    }
}
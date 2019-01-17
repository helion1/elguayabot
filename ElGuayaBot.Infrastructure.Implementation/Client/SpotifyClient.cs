using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;

namespace ElGuayaBot.Infrastructure.Implementation.Client
{
    public class SpotifyClient
    {
        private readonly ILogger<SpotifyClient> _logger;

        private readonly IConfiguration _configuration;
        
        public SpotifyWebAPI Client { get; private set; }

        public SpotifyClient(ILogger<SpotifyClient> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public SpotifyWebAPI GetClient()
        {
            try
            {
                var auth = new CredentialsAuth(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);
                var token = auth.GetToken().Result;
                
                Client = new SpotifyWebAPI
                {
                    TokenType = token.TokenType, 
                    AccessToken = token.AccessToken
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error setting SpotifyClient", e);
                
                throw;
            }

            return Client;
        }
    }
}
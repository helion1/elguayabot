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
        
        public readonly SpotifyWebAPI Client;


        public SpotifyClient(IConfiguration configuration, ILogger<SpotifyClient> logger)
        {
            _logger = logger;
            
            try
            {
                var auth = new CredentialsAuth(configuration["Spotify:ClientId"], configuration["Spotify:ClientSecret"]);
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
        }
    }
}
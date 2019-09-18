using System.Net.Http;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Model;
using ElGuayabot.Infrastructure.Contract.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Infrastructure.Implementation.Service
{
    public class GifSearchService : IGifSearchService
    {
        protected ILogger<GifSearchService> Logger;
        protected HttpClient Client;
        protected readonly string API_KEY;
        
        public GifSearchService(ILogger<GifSearchService> logger, HttpClient client,  IConfiguration configuration)
        {
            client.BaseAddress = new System.Uri(configuration["GIPHY_API_URL"]);
            Logger = logger;
            Client = client;
            API_KEY = configuration["GIPHY_API_KEY"];
        }

        public async Task<Result<string>> GetRandomGif(string[] searchParams)
        {
            var requestResponse = await Client.GetAsync($"search?q={searchParams}&api_key={API_KEY}&limit={20}");

            var giphySearchResponse = requestResponse.Content.ReadAsAsync<GiphySearchResponse>();
            
            return Result<string>.Success("TODO");
        }
    }
}
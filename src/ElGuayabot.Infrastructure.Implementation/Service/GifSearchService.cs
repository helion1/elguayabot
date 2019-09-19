using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Service;
using ElGuayabot.Infrastructure.Implementation.Model;
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

        public async Task<Result<string>> GetRandomGif(params string[] searchParams)
        {
            var searchQuery = string.Join('+', searchParams);
            var requestResponse = await Client.GetAsync($"search?q={searchQuery}&rating=R&api_key={API_KEY}&limit={20}");

            var giphySearchResponse = await requestResponse.Content.ReadAsAsync<GiphySearchResponse>();

            var r = new Random().Next(giphySearchResponse.Data.Length);

            var luckyGif = giphySearchResponse.Data[r].Images.Original.Mp4;
            
            return Result<string>.Success(luckyGif);
        }
    }
}
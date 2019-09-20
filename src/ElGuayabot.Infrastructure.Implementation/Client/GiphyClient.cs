using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Client;
using ElGuayabot.Infrastructure.Implementation.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Infrastructure.Implementation.Client
{
    public class GiphyClient : IGiphyClient
    {
        protected readonly ILogger<GiphyClient> Logger;
        protected readonly HttpClient Client;
        protected readonly string API_KEY;

        public GiphyClient(ILogger<GiphyClient> logger, HttpClient client,  IConfiguration configuration)
        {
            client.BaseAddress = new System.Uri(configuration["GIPHY_API_URL"]);
            Logger = logger;
            Client = client;
            API_KEY = configuration["GIPHY_API_KEY"];
        }
        
        public async Task<Result<GiphySearchResponse>> Search(params string[] searchParams)
        {
            var searchQuery = string.Join('+', searchParams);
            var requestResponse = await Client.GetAsync($"search?q={searchQuery}&rating=R&api_key={API_KEY}&limit={25}");

            if (!requestResponse.IsSuccessStatusCode)
            {
                return Result<GiphySearchResponse>.Fail(requestResponse.StatusCode.ToString(), new List<string> {requestResponse.ReasonPhrase});
            }

            var giphySearchResponse = await requestResponse.Content.ReadAsAsync<GiphySearchResponse>();
                
            return Result<GiphySearchResponse>.Success(giphySearchResponse);

        }
    }
}
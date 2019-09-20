using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Infrastructure.Implementation.Client
{
    public class GoogleSearchClient : IGoogleSearchClient
    {
        protected readonly ILogger<GoogleSearchClient> Logger;
        protected readonly HttpClient Client;
        protected readonly string API_KEY;

        public GoogleSearchClient(ILogger<GoogleSearchClient> logger, HttpClient client,  IConfiguration configuration)
        {
            client.BaseAddress = new System.Uri(configuration["GOOGLE_URL"] ?? "https://www.google.com/");
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html, application/xhtml+xml, */*"));
            
            client.DefaultRequestHeaders.UserAgent.Clear();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko"));
            
            Logger = logger;
            Client = client;
        }
        
        public async Task<Result<string>> Search(params string[] searchParams)
        {
            try
            {
                var searchQuery = string.Join('+', searchParams);

                var searchResponse = await Client.GetAsync($"search?q={searchQuery}&tbm=isch");

                if (!searchResponse.IsSuccessStatusCode)
                {
                    return Result<string>.Fail(searchResponse.StatusCode.ToString(), new List<string> {searchResponse.ReasonPhrase});
                }

                var content = await searchResponse.Content.ReadAsStringAsync();
            
                return Result<string>.Success(content);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Unhandled error executing a google search.");
                return Result<string>.UnknownError(new List<string> {e.Message});
            }
        }
    }
}
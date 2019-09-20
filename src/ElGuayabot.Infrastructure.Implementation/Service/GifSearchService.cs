using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ElGuayabot.Common.Helper;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Client;
using ElGuayabot.Infrastructure.Contract.Service;
using ElGuayabot.Infrastructure.Implementation.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Infrastructure.Implementation.Service
{
    public class GifSearchService : IGifSearchService
    {
        protected ILogger<GifSearchService> Logger;
        protected IGiphyClient Client;

        public GifSearchService(ILogger<GifSearchService> logger, IGiphyClient client)
        {
            Logger = logger;
            Client = client;
        }

        public async Task<Result<string>> GetRandomGif(params string[] searchParams)
        {
            var searchResult = await Client.Search(searchParams);

            if (!searchResult.Succeeded)
            {
                return Result<string>.FromResult(searchResult);
            }
            
            var r = RandomProvider.GetThreadRandom().Next(searchResult.Value.Data.Length);

            var luckyGif = searchResult.Value.Data[r].Images.Original.Mp4;
            
            return Result<string>.Success(luckyGif);
        }
    }
}
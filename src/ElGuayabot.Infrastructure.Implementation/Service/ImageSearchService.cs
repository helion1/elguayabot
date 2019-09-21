using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElGuayabot.Common.Helper;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Contract.Client;
using ElGuayabot.Infrastructure.Contract.Service;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Infrastructure.Implementation.Service
{
    public class ImageSearchService : IImageSearchService
    {
        protected ILogger<ImageSearchService> Logger;
        protected readonly IGoogleSearchClient Client;

        public ImageSearchService(ILogger<ImageSearchService> logger, IGoogleSearchClient client)
        {
            Logger = logger;
            Client = client;
        }

        public async Task<Result<string>> GetRandomUrl(params string[] searchParams)
        {
            var searchResult = await Client.Search(searchParams);

            if (!searchResult.Succeeded)
            {
                return Result<string>.FromResult(searchResult);
            }

            var urlsResult = GetUrls(searchResult.Value);

            if (!urlsResult.Succeeded)
            {
                return Result<string>.FromResult(urlsResult);
            }
            
            var r = RandomProvider.GetThreadRandom().Next(urlsResult.Value.Length);

            var luckyUrl = urlsResult.Value[r];
            
            return Result<string>.Success(luckyUrl);
        }
        
        private Result<string[]> GetUrls(string html)
        {
            try
            {
                var urlList = new List<string>();

                int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);

                while (ndx >= 0)
                {
                    ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
                    ndx++;
                    int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
                    string url = html.Substring(ndx, ndx2 - ndx);
                    urlList.Add(url);
                    ndx = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
                }
                return Result<string[]>.Success(urlList.ToArray());
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error parsing URLs in ImageSearchService");
                
                return Result<string[]>.UnknownError(new List<string> {e.Message});
            }
        }
    }
}
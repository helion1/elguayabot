using ElGuayaBot.Infrastructure.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElGuayaBot.Infrastructure.Implementation.Service
{
    public class PictureSearchService : IPictureSearchService
    {
        public IEnumerable<string> GetGifUrlList(string[] topics, int quantity = 50)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetImageUrlList(string[] topics, int quantity = 50)
        {
            throw new NotImplementedException();
        }

        public string GetRandomGif(string[] topics)
        {
            throw new NotImplementedException();
        }

        public string GetRandomImage(string[] topics)
        {
            throw new NotImplementedException();
        }
    }
}

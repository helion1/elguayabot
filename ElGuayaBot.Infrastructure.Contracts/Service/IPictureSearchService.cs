using System;
using System.Collections.Generic;
using System.Text;

namespace ElGuayaBot.Infrastructure.Contracts.Service
{
    public interface IPictureSearchService
    {
        IEnumerable<string> GetImageUrlList(string[] topics, int quantity = 50);

        IEnumerable<string> GetGifUrlList(string[] topics, int quantity = 50);

        string GetRandomImage(string[] topics);

        string GetRandomGif(string[] topics);
    }
}

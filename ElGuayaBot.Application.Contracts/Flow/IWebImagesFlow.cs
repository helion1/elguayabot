using System;
using System.Collections.Generic;
using System.Text;

namespace ElGuayaBot.Application.Contracts.Flow
{
    public interface IWebImagesFlow : IBaseFlow
    {
        string GetHtmlCode();
        List<string> GetUrls(string html);
    }
}

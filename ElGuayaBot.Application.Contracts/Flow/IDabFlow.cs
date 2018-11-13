using System;
using System.Collections.Generic;
using System.Text;

namespace ElGuayaBot.Application.Contracts.Flow
{
    public interface IDabFlow : IWebImagesFlow
    {
        bool CheckGifUrlExtension(string url);
    }
}

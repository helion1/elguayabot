using ElGuayabot.Application.Contract.Common.Responses;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Application.Implementation.Common.Response.Sticker
{
    public class StickerResponse : Request<Result>, IResponse
    {
        public string Sticker { get; set; }

        public StickerResponse(string sticker)
        {
            Sticker = sticker;
        }
    }
}
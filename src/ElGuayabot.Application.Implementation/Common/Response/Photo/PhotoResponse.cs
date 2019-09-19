using ElGuayabot.Application.Contract.Common.Responses;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Application.Implementation.Common.Response.Photo
{
    public class PhotoResponse : Request<Result>, IResponse
    {
        public string Photo { get; set; }

        public PhotoResponse(string photo)
        {
            Photo = photo;
        }
    }
}
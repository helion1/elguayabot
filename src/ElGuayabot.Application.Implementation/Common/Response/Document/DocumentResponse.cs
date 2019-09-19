using ElGuayabot.Application.Contract.Common.Responses;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Application.Implementation.Common.Response.Document
{
    public class DocumentResponse : Request<Result>, IResponse
    {
        public object Document { get; set; }
        public int MessageId { get; set; }

        public DocumentResponse(object document, int messageId = 0)
        {
            Document = document;
            MessageId = messageId;
        }
    }
}
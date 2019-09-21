using ElGuayabot.Application.Contract.Common.Responses;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Application.Implementation.Common.Response.Document
{
    public class DocumentResponse : Request<Result>, IResponse
    {
        public string Document { get; set; }
        public string Caption { get; set; }
        public int MessageId { get; set; }

        public DocumentResponse(string document, string caption = "", int messageId = 0)
        {
            Document = document;
            Caption = caption;
            MessageId = messageId;
        }
    }
}
using System.Net;

namespace HepsiYemekApi.Common.ResponsesModel
{
    public class ErrorResponse:Response
    {
        public ErrorResponse() : base(false)
        {
        }
        
        public ErrorResponse(HttpStatusCode statusCode) : base(false, statusCode)
        {
        }
        
        public ErrorResponse(HttpStatusCode statusCode, string message) : base(false, statusCode, message)
        {
        }
    }
}
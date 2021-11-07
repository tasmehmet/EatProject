using System.Net;

namespace HepsiYemekApi.Common.ResponsesModel
{
    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(true)
        {
        }

        public SuccessResponse(HttpStatusCode statusCode) : base(true, statusCode)
        {
        }

    }
}
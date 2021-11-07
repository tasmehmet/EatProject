using System.Net;

namespace HepsiYemekApi.Common.ResponsesModel
{
    public class SuccessDataResponse<T> : DataResponse<T> where T : class, new()
    {

        public SuccessDataResponse(T data, HttpStatusCode statusCode) : base(data, true, statusCode)
        {
        }
        
    }
}
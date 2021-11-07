using System.Net;
using System.Text.Json.Serialization;

namespace HepsiYemekApi.Common.ResponsesModel
{
    public interface IResponse
    {
        [JsonPropertyName("success")]
        bool Success { get; }

        [JsonPropertyName("message")]
        string Message { get; }
        
        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; }
    }
}
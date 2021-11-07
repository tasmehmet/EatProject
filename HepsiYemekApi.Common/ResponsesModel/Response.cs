using System;
using System.Net;
using System.Text.Json.Serialization;

namespace HepsiYemekApi.Common.ResponsesModel
{
    [Serializable]
    public class Response: IResponse
    {
        public Response(bool success)
        {
            Success = success;
        }
        
        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }
        
        public Response(bool success, HttpStatusCode statusCode) : this(success)
        {
            StatusCode = statusCode;
        }
        
        public Response(bool success, HttpStatusCode statusCode, string message) : this(success, message)
        {
            StatusCode = statusCode;
        }

        [JsonPropertyName("success")]
        public bool Success { get; }
        
        
        [JsonPropertyName("message")]
        public string Message { get; }
        
        
        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; }
    }
}
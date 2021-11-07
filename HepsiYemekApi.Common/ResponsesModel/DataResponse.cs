using System.Net;
using System.Text.Json.Serialization;

namespace HepsiYemekApi.Common.ResponsesModel
{
    public class DataResponse<T> : Response, IDataResponse<T> where T : class, new()
    {
        public DataResponse(T data, bool success) : base(success)
        {
            Items = data;
        }
        

        public DataResponse(T data, bool success, HttpStatusCode statusCode) : base(success, statusCode)
        {
            Items = data;
        }

        public DataResponse(T data, bool success, HttpStatusCode statusCode, int size) : this(data, success, statusCode)
        {
            Size = size;
        }

        public DataResponse(T data, bool success, string message) : base(success, message)
        {
            Items = data;
        }

        public DataResponse(T data, bool success, HttpStatusCode statusCode, string message) : base(success, statusCode,
            message)
        {
            Items = data;
        }

        [JsonPropertyName("items")]
        public T Items { get; }
        
        [JsonPropertyName("size")]
        public int Size { get; }
    }
}
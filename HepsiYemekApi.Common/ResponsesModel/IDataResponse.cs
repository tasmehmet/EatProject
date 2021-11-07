using System.Text.Json.Serialization;

namespace HepsiYemekApi.Common.ResponsesModel
{
    public interface IDataResponse<out T> : IResponse where T : class, new()
    {
        [JsonPropertyName("items")]
        T Items { get; }
        
        [JsonPropertyName("size")]
        public int Size { get; }
    }
}
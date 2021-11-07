using System.Text.Json;
using System.Text.Json.Serialization;

namespace HepsiYemekApi.Common.Extensions
{
    public static class StringExtensions
    {
        public static TDest FromJson<TDest>(this string source)
        {
            return JsonSerializer.Deserialize<TDest>(source, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                Converters = {new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)}
            });
        } 
        
        public static string AsJson(this object source)
        {
            return JsonSerializer.Serialize(source, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                Converters = {new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)}
            });
        }
    }
}
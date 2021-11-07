using System;
using System.Threading.Tasks;

namespace HepsiYemekApi.Core.Caching.Redis
{
    public interface IRedisCacheService: IDisposable
    {
        Task<T> GetAsync<T>(string key);

        bool Set(string key, object data, TimeSpan? expiry = null);

        Task<bool> IsExistsAsync(string key);
        
        Task<bool> RemoveAsync(string key);
    }
}
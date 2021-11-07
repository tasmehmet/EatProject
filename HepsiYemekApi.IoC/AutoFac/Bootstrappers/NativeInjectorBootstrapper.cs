using HepsiYemekApi.Core.Caching.Redis;
using HepsiYemekApi.Entitiy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HepsiYemekApi.IoC.AutoFac.Bootstrappers
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterNativeServices(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.AddSingleton<IOptions<RedisCacheSettings>>(_ => new OptionsWrapper<RedisCacheSettings>(
                new RedisCacheSettings()
                {
                    ConnectionString = configuration.GetSection("RedisCacheSettings:ConnectionString").Value,
                    InstanceName = configuration.GetSection("RedisCacheSettings:InstanceName").Value
                }
            ));

            services.AddSingleton<IOptions<MongoDbSettings>>(_ => new OptionsWrapper<MongoDbSettings>(
                new MongoDbSettings()
                {
                    ConnectionString = configuration.GetSection("MongoDbSettings:ConnectionString").Value,
                    Database = configuration.GetSection("MongoDbSettings:Database").Value,
                }));
        }
    }
}
using Autofac;
using HepsiYemekApi.Core.Caching.Redis;

namespace HepsiYemekApi.IoC.AutoFac.Modules
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RedisCacheService>().As<IRedisCacheService>();
        }
    }
}
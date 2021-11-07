using System;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiYemekApi.Core.Mapping
{
    public class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}
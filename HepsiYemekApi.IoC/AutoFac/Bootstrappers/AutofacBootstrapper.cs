using Autofac;
using HepsiYemekApi.IoC.AutoFac.Modules;

namespace HepsiYemekApi.IoC.AutoFac.Bootstrappers
{
    public class AutofacBootstrapper
    {
        public static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new DataAccessModule());
            builder.RegisterModule(new BusinessModule());
            builder.RegisterModule(new CoreModule());
        }
    }
}
using Autofac;
using HepsiYemekApi.Business.Abstract;
using HepsiYemekApi.Business.Concrete;

namespace HepsiYemekApi.IoC.AutoFac.Modules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
        }
    }
}
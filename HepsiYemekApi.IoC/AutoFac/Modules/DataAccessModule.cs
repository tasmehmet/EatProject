using Autofac;
using HepsiYemekApi.DataAccess.Abstract;
using HepsiYemekApi.DataAccess.Concrete;

namespace HepsiYemekApi.IoC.AutoFac.Modules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDal>().As<IProductDal>();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>();
        }
    }
}
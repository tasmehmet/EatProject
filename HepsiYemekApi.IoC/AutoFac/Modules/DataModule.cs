using Autofac;
using HepsiYemekApi.Data;
using HepsiYemekApi.Repository.Abstract;
using HepsiYemekApi.Repository.Concrete;

namespace HepsiYemekApi.IoC.AutoFac.Modules
{
    public class DataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDbConnector>().As<IMongoDbConnector>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
        }
    }
}
using HepsiYemekApi.Data;
using HepsiYemekApi.Entitiy;
using HepsiYemekApi.Repository.Abstract;

namespace HepsiYemekApi.Repository.Concrete
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(IMongoDbConnector mongoDbConnector)
            : base(mongoDbConnector)
        {
        }
    }
}
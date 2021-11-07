using HepsiYemekApi.Data;
using HepsiYemekApi.Entitiy;
using HepsiYemekApi.Repository.Abstract;

namespace HepsiYemekApi.Repository.Concrete
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(IMongoDbConnector connector) : base(connector)
        {
        }
        
    }
}
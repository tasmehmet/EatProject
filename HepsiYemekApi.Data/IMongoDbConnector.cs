using MongoDB.Driver;

namespace HepsiYemekApi.Data
{
    public interface IMongoDbConnector
    {
        IMongoDatabase MongoDatabase { get; }
    }
}
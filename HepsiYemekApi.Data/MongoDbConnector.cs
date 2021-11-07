using System;
using HepsiYemekApi.Entitiy;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HepsiYemekApi.Data
{
    public class MongoDbConnector:IMongoDbConnector
    {
        public IMongoDatabase MongoDatabase { get; private set; }
        private readonly MongoDbSettings _mongoDbSettings;
        public MongoDbConnector(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings.Value ?? throw new ArgumentNullException(nameof(mongoDbSettings.Value));
            CreateMongoClient();
        }
        private void CreateMongoClient()
        {
            if (this.MongoDatabase is null)
            {
                var connectionString = _mongoDbSettings.ConnectionString;
                var defaultDb = _mongoDbSettings.Database;
                var client = new MongoClient(connectionString);
                this.MongoDatabase = client.GetDatabase(defaultDb);
            }
        }
    }
}
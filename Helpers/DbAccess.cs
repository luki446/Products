using MongoDB.Driver;
using Product.Models;

namespace Product.Helpers
{
    public class DbAccess
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public IMongoCollection<ProductModel> Collection {get; set;}
        public DbAccess(string ConnectionString)
        {
            _client = new MongoClient(ConnectionString);
            _database = _client.GetDatabase("ProductsProject");

            Collection = _database.GetCollection<ProductModel>("Products");
        }
    }
}
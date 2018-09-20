using Microsoft.Extensions.Options;
using MongoDB.Driver;
using LHMSAPI.Models;

namespace LHMSAPI.Models
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _database = null;
        public DatabaseContext(IOptions<Settings> settings)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("LHMS");
        }

        public IMongoCollection<SystemReport> SystemReports
        {
            get 
            {
                return _database.GetCollection<SystemReport>("SystemReport");
            }
        }

        public IMongoCollection<User> Users
        {
            get 
            {
                return _database.GetCollection<User>("users");
            }
        }
    }
}
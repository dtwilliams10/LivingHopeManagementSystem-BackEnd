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
            var client = new MongoClient("mongodb://mongodb:27017/");
            _database = client.GetDatabase("LHMS");
        }

        public IMongoCollection<SystemReport> SystemReports
        {
            get
            {
                return _database.GetCollection<SystemReport>("systemreports");
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
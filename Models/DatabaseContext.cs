using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using LHMSAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LHMSAPI.Models
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _database = null;
        
        public DatabaseContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("LHMS");
        }

        public string GetDatabaseStatus()
        {
            var command = new BsonDocument {{ "dbStats", 1}, {"scale", 1}};
            var result = _database.RunCommand<BsonDocument>(command);
            Debug.WriteLine(result.ToJson());
            Debug.Print(result.ToJson());
            string status = result.ToJson();
            return status;
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
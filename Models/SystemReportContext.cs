using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LHMSAPI.Models
{
    public class SystemReportContext
    {
        private readonly IMongoDatabase _database = null;

        public SystemReportContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<SystemReport> SystemReports
        {
            get 
            {
                return _database.GetCollection<SystemReport>("SystemReport");
            }
        }
    }
}
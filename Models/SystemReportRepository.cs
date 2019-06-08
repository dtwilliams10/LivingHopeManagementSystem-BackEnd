using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LHMSAPI.Models
{
    public class SystemReportRepository
    {
        private readonly IMongoCollection<SystemReport> _systemReport = null;

        public SystemReportRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("LHMS");
            _systemReport = database.GetCollection<SystemReport>("SystemReport");
        }

        public async Task AddSystemReport(SystemReport systemReport)
        {
            try
            {
                await _systemReport.InsertOneAsync(systemReport);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SystemReport>> GetAllSystemReports()
        {
            try {
                return await _systemReport.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SystemReport> GetSystemReport(string id)
        {
            try
            {
                ObjectId internalId = GetObjectId(id);
                return await _systemReport.Find(SystemReport => SystemReport.ReportID == id
                || SystemReport.ObjectID == internalId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public async Task<bool> RemoveSystemReport(string id)
        {
            try
            {
                DeleteResult actionResult = await _systemReport.DeleteOneAsync(
                    Builders<SystemReport>.Filter.Eq("Id", id));

                    return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> UpdateSystemReport(string id, string body) //TODO Need to figure out how to determine the field that is being updated.
        {
            throw new NotImplementedException();
        }

        private ObjectId GetObjectId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
            internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
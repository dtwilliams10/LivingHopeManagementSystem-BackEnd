using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LHMSAPI.Models
{
    public class SystemReportRepository : ISystemReportRepository
    {
        private readonly SystemReportContext _context = null;

        public SystemReportRepository(IOptions<Settings> settings) 
        {
            _context = new SystemReportContext(settings);    
        }

        public async Task AddSystemReport(SystemReport systemReport)
        {
            try 
            {
                await _context.SystemReports.InsertOneAsync(systemReport);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SystemReport>> GetAllSystemReports()
        {
            try {
                return await _context.SystemReports.Find(_ => true).ToListAsync();
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
                return await _context.SystemReports.Find(SystemReport => SystemReport.ReportID == id
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
                DeleteResult actionResult = await _context.SystemReports.DeleteOneAsync(
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

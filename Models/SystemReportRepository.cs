using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace LHMSAPI.Models
{
    public class SystemReportRepository
    {

        public SystemReportRepository(IConfiguration config)
        {
            throw new NotImplementedException();
        }

        public Task AddSystemReport(SystemReport systemReport)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SystemReport>> GetAllSystemReports()
        {
            throw new NotImplementedException();
        }

        public Task<SystemReport> GetSystemReport(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveSystemReport(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSystemReport(string id, string body) //TODO Need to figure out how to determine the field that is being updated.
        {
            throw new NotImplementedException();
        }

        private int GetObjectId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
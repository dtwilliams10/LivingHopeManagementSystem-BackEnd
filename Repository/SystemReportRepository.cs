using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;   

namespace LHMSAPI.Repository
{
    public class SystemReportRepository: IRepository<SystemReport>
    {
        SystemReportRepository(IConfiguration config)
        {
            throw new NotImplementedException();
        }

        public SystemReportRepository()
        {
        }

        public string Add()
        {
            return "test call for Add System Report";
        }

        void Delete(SystemReport item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SystemReport>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SystemReport> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> RemoveSystemReport(int id)
        {
            throw new NotImplementedException();
        }

        void Update(SystemReport item)
        {
            throw new NotImplementedException();
        }

        void IRepository<SystemReport>.Add(SystemReport item)
        {
            throw new NotImplementedException();
        }

        void IRepository<SystemReport>.Delete(SystemReport item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<SystemReport> IRepository<SystemReport>.GetAll()
        {
            throw new NotImplementedException();
        }

        SystemReport IRepository<SystemReport>.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<SystemReport>.Update(SystemReport item)
        {
            throw new NotImplementedException();
        }
    }
}
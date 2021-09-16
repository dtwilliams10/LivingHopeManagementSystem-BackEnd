using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Models;
using System;
using System.Collections.Generic;

namespace LHMS.SystemReports.Services
{
    public interface ISystemNameService
    {
        IEnumerable<SystemName> GetAllSystemNames();
    }

    public class SystemNameService : ISystemNameService
    {
        private readonly DatabaseContext _context;

        public SystemNameService(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<SystemName> GetAllSystemNames()
        {
            try
            {
                var systemNames = _context.SystemName.AsQueryable();
                return systemNames;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Error in System Name Service: {@ex}", ex);
                throw new AppException();
            }
        }
    }
}
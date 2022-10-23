using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LHMS.SystemReports.Services
{
    public interface ISystemNameService
    {
        IQueryable<SystemName> GetAllSystemNames();
    }

    public class SystemNameService : ISystemNameService
    {
        private readonly DatabaseContext _context;

        public SystemNameService(DatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<SystemName> GetAllSystemNames()
        {
            try
            {
                var systemNames = _context.SystemNames;
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
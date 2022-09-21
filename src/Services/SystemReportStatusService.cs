using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Entities;
using System;
using System.Collections.Generic;

namespace LHMS.SystemReports.Services
{
    public interface ISystemReportStatusService
    {
        IEnumerable<SystemReportStatus> GetAllSystemReportStatuses();
    }

    public class SystemReportStatusService : ISystemReportStatusService
    {
        private readonly DatabaseContext _context;

        public SystemReportStatusService(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<SystemReportStatus> GetAllSystemReportStatuses()
        {
            try
            {
                var systemReportStatuses = _context.SystemReportStatus.AsQueryable();
                return systemReportStatuses;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Error in System Report Service: {@ex}", ex);
                throw new AppException();
            }
        }
    }
}
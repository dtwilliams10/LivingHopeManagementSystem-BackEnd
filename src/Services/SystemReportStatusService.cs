using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LHMS.SystemReports.Services
{
    public interface ISystemReportStatusService
    {
        Task<List<SystemReportStatus>> GetAllSystemReportStatuses();
    }

    public class SystemReportStatusService : ISystemReportStatusService
    {
        private readonly DatabaseContext _context;

        public SystemReportStatusService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<SystemReportStatus>> GetAllSystemReportStatuses()
        {
            try
            {
                var systemReportStatuses = await _context.SystemReportStatus.AsQueryable().ToListAsync();
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
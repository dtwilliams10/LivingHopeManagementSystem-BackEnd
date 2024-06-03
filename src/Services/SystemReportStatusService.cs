using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LHMS.SystemReports.Services
{
    public interface ISystemReportStatusService
    {
        Task<List<SystemReportStatus>> GetAllSystemReportStatuses();

        Task<SystemReportStatus> GetSystemReportStatusById(int id);
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
                var systemReportStatuses = await _context.SystemReportStatus.AsQueryable<SystemReportStatus>().ToListAsync();
                return systemReportStatuses;
            }
            catch (Exception Ex)
            {
                Serilog.Log.Error(Ex, "Error in System Report Service: {Ex}");
                throw new AppException();
            }
        }

        public async Task<SystemReportStatus> GetSystemReportStatusById(int id)
        {
            try
            {
                var systemReportStatus = await _context.SystemReportStatus.FirstOrDefaultAsync(x => x.Id == id);
                return systemReportStatus;
            }
            catch (Exception Ex)
            {
                Serilog.Log.Error(Ex, "Error in System Report Status Service: {Ex}");
                throw new AppException();
            }
        }
    }
}
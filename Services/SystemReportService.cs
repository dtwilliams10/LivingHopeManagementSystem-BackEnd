using System;
using System.Collections.Generic;
using System.Linq;
using LHMSAPI.Helpers;
using LHMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LHMSAPI.Services
{
    public interface ISystemReportService
    {
        IEnumerable<SystemReport> GetAllSystemReports();

        IEnumerable<SystemReport> GetLoggedInUsersSystemReports();

        SystemReport GetByID(int id);

        SystemReport Create(SystemReport model);

        SystemReport Update(int id, SystemReport model);

        void Delete(int id);
    }

    public class SystemReportService : ISystemReportService
    {
        private readonly DatabaseContext _context;

        public SystemReportService(DatabaseContext context)
        {
            _context = context;
        }

        public SystemReport Create(SystemReport model)
        {
            //TODO: Add logic to pull logged in user and assign to Reporter spot.
            var systemReport = model;
            systemReport.Active = true;
            try {
                systemReport.Active = true;
                _context.SystemReports.Add(systemReport);
                return systemReport;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Error in System Report Service: {@ex}", ex);
                throw new AppException();
            }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SystemReport> GetAllSystemReports()
        {
            List<SystemReport> systemReports = _context.SystemReports.Where(s => s.Active == true).Include(name => name.SystemName).Include(status => status.SystemReportStatus).AsNoTracking().ToList();
            foreach(SystemReport sr in systemReports)
            {
               sr.SystemName.Name = _context.SystemName.Find(sr.SystemNameId).Name.ToString();
               sr.SystemReportStatus.Status = _context.SystemStatus.Find(sr.SystemReportStatusId).Status.ToString();
            }

            return systemReports;
        }

        public SystemReport GetByID(int id)
        {
            SystemReport systemReport = _context.SystemReports.SingleOrDefault(s => s.Id == id);
            return systemReport;
        }

        public IEnumerable<SystemReport> GetLoggedInUsersSystemReports()
        {
            throw new System.NotImplementedException();
        }

        public SystemReport Update(int id, SystemReport model)
        {
            throw new System.NotImplementedException();
        }
    }
}
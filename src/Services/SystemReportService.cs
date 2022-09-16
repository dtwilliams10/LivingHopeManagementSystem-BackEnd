using System;
using System.Collections.Generic;
using System.Linq;
using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LHMS.SystemReports.Services
{
    public interface ISystemReportService
    {
        IQueryable<SystemReport> GetAllSystemReports();

        IQueryable<SystemReport> GetLoggedInUsersSystemReports();

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

        public SystemReport Create(SystemReport systemReport)
        {
            try
            {
                //TODO: Add logic to pull logged in user and assign to Reporter spot.
                systemReport.CreatedDate = DateTime.Now;
                systemReport.UpdatedDate = DateTime.Now;
                if (systemReport.SystemReportStatusId == 0)
                    systemReport.SystemReportStatusId = 1;
                systemReport.SystemName = _context.SystemNames.Find(systemReport.SystemNameId);
                systemReport.SystemReportStatus = _context.SystemReportStatus.Find(systemReport.SystemReportStatusId);
                _context.SystemReports.AddAsync(systemReport);
                _context.SaveChanges();
                return systemReport;
            }
            catch (Exception ex)
            {
                Log.Error("Error in System Report Service: {@ex}", ex.ToString());
                Log.Error(ex.InnerException.Message);
                throw new AppException();
            }
        }

        public void Delete(int id)
        {
            /*Check if the record with the provided ID exists. If it does, delete it. If not return an error/success*/
            SystemReport systemReport = _context.SystemReports.SingleOrDefault(s => s.Id == id);
            if (systemReport != null)
            {
                try
                {
                    _context.SystemReports.Remove(systemReport);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Error("Error deleting System Report with ID: {@id}", ex);
                    throw new AppException();
                }
            }

        }

        public IQueryable<SystemReport> GetAllSystemReports()
        {
            IQueryable<SystemReport> systemReports = _context.SystemReports.Where(s => s.SystemReportStatusId > 1).Include(name => name.SystemName).Include(status => status.SystemReportStatus).AsNoTracking();
            foreach (SystemReport sr in systemReports)
            {
                sr.SystemName.Name = _context.SystemNames.Find(sr.SystemNameId).Name.ToString();
                sr.SystemReportStatus.Status = _context.SystemReportStatus.Find(sr.SystemReportStatusId).Status.ToString();
            }

            return systemReports;
        }

        public SystemReport GetByID(int id)
        {
            SystemReport systemReport = _context.SystemReports.FirstOrDefault(s => s.Id == id);
            systemReport.SystemName = _context.SystemNames.FirstOrDefault(s => s.Id == systemReport.SystemNameId);
            systemReport.SystemReportStatus = _context.SystemReportStatus.FirstOrDefault(s => s.Id == systemReport.SystemReportStatusId);
            return systemReport;
        }

        public IQueryable<SystemReport> GetLoggedInUsersSystemReports()
        {
            throw new System.NotImplementedException();
        }

        public SystemReport Update(int id, SystemReport model)
        {
            //IQueryable<SystemReport> systemReports = _context.SystemReports.Where(s => s.)
            throw new System.NotImplementedException();
        }
    }
}
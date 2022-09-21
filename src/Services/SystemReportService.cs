using System;
using System.Collections.Generic;
using System.Linq;
using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Models.SystemReport;
using LHMS.SystemReports.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using AutoMapper;

namespace LHMS.SystemReports.Services
{
    public interface ISystemReportService
    {
        IQueryable<SystemReportResponse> GetAllSystemReports();

        IQueryable<SystemReportResponse> GetLoggedInUsersSystemReports();

        SystemReportResponse GetByID(int id);

        SystemReportResponse Create(SystemReportRequest model);

        SystemReportResponse Update(SystemReportRequest model);

        void Delete(int id);
    }

    public class SystemReportService : ISystemReportService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public SystemReportService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SystemReportResponse Create(SystemReportRequest systemReportRequest)
        {
            try
            {

                var systemReport = _mapper.Map<SystemReport>(systemReportRequest);
                //TODO: Add logic to pull logged in user and assign to Reporter spot.
                systemReport.CreatedDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow);
                systemReport.UpdatedDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow);
                if (systemReport.SystemReportStatusId == 0)
                    systemReport.SystemReportStatusId = 1;
                _context.SystemReports.AddAsync(systemReport);
                _context.SaveChanges();

                var response = _mapper.Map<SystemReportResponse>(systemReport);
                return response;
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
            var systemReport = _context.SystemReports.SingleOrDefault(s => s.Id == id);
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

        public IQueryable<SystemReportResponse> GetAllSystemReports()
        {
            var systemReports = _context.SystemReports.Where(s => s.SystemReportStatusId > 1).Include(name => name.SystemName).Include(status => status.SystemReportStatus).AsQueryable();
            
            IQueryable<SystemReportResponse> response = null;
            foreach(SystemReport sr in systemReports)
            {
                var mappedReport = _mapper.Map<SystemReportResponse>(sr);
                response.Append(mappedReport);
            }
            
            return response;
        }

        public SystemReportResponse GetByID(int id)
        {
            var systemReport = _context.SystemReports.FirstOrDefault(s => s.Id == id);
            systemReport.SystemName = _context.SystemNames.FirstOrDefault(s => s.Id == systemReport.SystemNameId);
            systemReport.SystemReportStatus = _context.SystemReportStatus.FirstOrDefault(s => s.Id == systemReport.SystemReportStatusId);

            var response = _mapper.Map<SystemReportResponse>(systemReport);
            return response;
        }

        public IQueryable<SystemReportResponse> GetLoggedInUsersSystemReports()
        {
            throw new System.NotImplementedException();
        }

        public SystemReportResponse Update(SystemReportRequest systemReport)
        {
            //IQueryable<SystemReport> systemReports = _context.SystemReports.Where(s => s.)
            throw new System.NotImplementedException();
        }
    }
}
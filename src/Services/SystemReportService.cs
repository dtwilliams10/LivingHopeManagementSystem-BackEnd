using System;
using System.Collections.Generic;
using System.Linq;
using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Models.SystemReport;
using LHMS.SystemReports.Entities;
using Serilog;
using AutoMapper;
using System.Threading.Tasks;

namespace LHMS.SystemReports.Services
{
    public interface ISystemReportService
    {
        IQueryable<SystemReportResponse> GetAllSystemReports();

        IQueryable<SystemReportResponse> GetLoggedInUsersSystemReports();

        SystemReportResponse GetByID(int id);

        Task<SystemReportResponse> Create(SystemReportRequest model);

        Task<SystemReportResponse> Update(SystemReportRequest model);

        void Delete(int id);
    }

    public class SystemReportService : ISystemReportService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly ISystemNameService _systemNameService;
        private readonly ISystemReportStatusService _systemReportStatusService;

        public SystemReportService(DatabaseContext context, IMapper mapper, ISystemNameService systemNameService, ISystemReportStatusService systemReportStatusService)
        {
            _context = context;
            _mapper = mapper;
            _systemNameService = systemNameService;
            _systemReportStatusService = systemReportStatusService;
        }

        public async Task<SystemReportResponse> Create(SystemReportRequest systemReportRequest)
        {
            try
            {
                var systemReport = _mapper.Map<SystemReport>(systemReportRequest);
                //TODO: Add logic to pull logged in user and assign to Reporter spot.
                //Grab deserialized JWT and add the userID to reporterID. 
                systemReport.ReporterId = systemReportRequest.ReporterId.ToString();
                systemReport.CreatedDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow);
                systemReport.UpdatedDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow);
                systemReport.SystemReportStatus = await _systemReportStatusService.GetSystemReportStatusById(systemReport.SystemReportStatusId);
                if (systemReport.SystemReportStatusId == 0)
                    systemReport.SystemReportStatusId = 1;
                systemReport.SystemName = await _systemNameService.GetSystemNameById(systemReport.SystemNameId);
                await _context.SystemReports.AddAsync(systemReport);
                await _context.SaveChangesAsync();

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
            var systemReports = _context.SystemReports.ToList();

            List<SystemReportResponse> response = new();
            foreach (SystemReport sr in systemReports)
            {
                sr.SystemName = _context.SystemNames.FirstOrDefault(s => s.Id == sr.SystemNameId);
                sr.SystemReportStatus = _context.SystemReportStatus.FirstOrDefault(s => s.Id == sr.SystemReportStatusId);
                var mappedReport = _mapper.Map<SystemReportResponse>(sr);
                response.Add(mappedReport);
            }

            return response.AsQueryable();
        }

        public SystemReportResponse GetByID(int id)
        {
            SystemReport systemReport = _context.SystemReports.FirstOrDefault(s => s.Id == id);
            systemReport.SystemName = _context.SystemNames.FirstOrDefault(s => s.Id == systemReport.SystemNameId);
            systemReport.SystemReportStatus = _context.SystemReportStatus.FirstOrDefault(s => s.Id == systemReport.SystemReportStatusId);
            SystemReportResponse response = _mapper.Map<SystemReportResponse>(systemReport);
            return response;
        }

        public IQueryable<SystemReportResponse> GetLoggedInUsersSystemReports()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SystemReportResponse> Update(SystemReportRequest systemReportRequest)
        {
            try
            {
                SystemReport systemReport = await _context.SystemReports.FindAsync(systemReportRequest.Id);
                if (systemReport is not null)
                {
                    systemReport.BarriersOrChallenges = systemReportRequest.BarriersOrChallenges;
                    systemReport.CreativeIdeasAndEvaluations = systemReportRequest.CreativeIdeasAndEvaluations;
                    systemReport.HowCanIHelpYou = systemReportRequest.HowCanIHelpYou;
                    systemReport.PersonnelUpdates = systemReportRequest.PersonnelUpdates;
                    systemReport.PersonalGrowthAndDevelopment = systemReportRequest.PersonalGrowthAndDevelopment;
                    systemReport.SystemNameId = systemReportRequest.SystemName.Id;
                    systemReport.SystemReportStatusId = systemReportRequest.SystemReportStatus.Id;
                    systemReport.SystemUpdate = systemReportRequest.SystemUpdate;
                    systemReport.UpdatedDate = NodaTime.Instant.FromDateTimeUtc(DateTime.UtcNow);
                }

                SystemReportResponse response = _mapper.Map<SystemReportResponse>(systemReport);
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                Log.Error("Error updating System Report with ID: {@id}", systemReportRequest.Id);
                throw new AppException(ex.InnerException.ToString());
            }

        }
    }
}
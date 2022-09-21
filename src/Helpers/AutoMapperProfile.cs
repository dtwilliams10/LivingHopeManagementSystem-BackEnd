using AutoMapper;
using LHMS.SystemReports.Models.SystemReport;
using LHMS.SystemReports.Entities;
using LHMS.SystemReports.Models.SystemReportStatus;

namespace LHMS.SystemReports.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SystemReport, SystemReportResponse>();
            CreateMap<SystemName, SystemNameResponse>();
            CreateMap<SystemReportStatus, SystemReportStatusResponse>();
            CreateMap<SystemReportRequest, SystemReport>();
            CreateMap<SystemReportStatusRequest, SystemReportStatus>();
        }
    }
}
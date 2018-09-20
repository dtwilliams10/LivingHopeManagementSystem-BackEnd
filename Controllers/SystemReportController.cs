using Microsoft.AspNetCore.Mvc;
using LHMSAPI.Models;
using System.Threading.Tasks;
using LHMSAPI.Infrastructure;
using System.Collections.Generic;

namespace lhmsapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]    
    public class SystemReportController : ControllerBase
    {
        private readonly ISystemReportRepository _systemReportRepository;

        public SystemReportController(ISystemReportRepository systemReportRepository) {
            _systemReportRepository = systemReportRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<SystemReport>> Get() {
            return await _systemReportRepository.GetAllSystemReports();
        }

        [HttpGet("{id}")]
        public async Task<SystemReport> Get(string id) {
            return await _systemReportRepository.GetSystemReport(id) ?? new SystemReport();
        }

        [HttpPost]
        public void Post([FromBody] SystemReport newSystemReport) {
            _systemReportRepository.AddSystemReport(new SystemReport
            {
                //TODO: Need to autogenerate Report IDs for each team/system.
                ReportID = newSystemReport.ReportID,
                Name = newSystemReport.Name,
                ReportDate = newSystemReport.ReportDate,
                CreatedDate = newSystemReport.CreatedDate,
                UpdatedDate = newSystemReport.UpdatedDate,
                SystemName = newSystemReport.SystemName,
                SystemUpdate = newSystemReport.SystemUpdate,
                PersonnelUpdates = newSystemReport.PersonnelUpdates,
                CreativeIdeasAndEvaluations = newSystemReport.CreativeIdeasAndEvaluations,
                BarriersOrChallenges = newSystemReport.BarriersOrChallenges,
                HowCanIHelpYou = newSystemReport.HowCanIHelpYou,
                PersonalGrowthAndDevelopment = newSystemReport.PersonalGrowthAndDevelopment
            });
        }
    }
}
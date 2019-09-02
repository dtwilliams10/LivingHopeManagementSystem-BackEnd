using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LHMSAPI.Infrastructure;
using System.Collections.Generic;
using LHMSAPI.Repository;

namespace lhmsapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SystemReportController : ControllerBase
    {
        private readonly SystemReportRepository _systemReportRepository;

        public SystemReportController(SystemReportRepository systemReportRepository) {
            _systemReportRepository = systemReportRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<SystemReport>> Get() {
            return await _systemReportRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<SystemReport> Get(int id) {
            return await _systemReportRepository.GetByID(id) ?? new SystemReport();
        }

        [HttpPost]
        public string Add(){
            return _systemReportRepository.Add();
        }

        /*[HttpPost]
        public async void PostAsync([FromBody] SystemReport newSystemReport) {
            await _systemReportRepository.AddSystemReport(new SystemReport
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
        } */ 
    }
}
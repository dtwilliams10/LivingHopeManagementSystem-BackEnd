using Microsoft.AspNetCore.Mvc;
using LHMSAPI.Models;
using System.Threading.Tasks;

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
        public async Task<SystemReport> Get() {
            return await _systemReportRepository.GetAllSystemReports();
        }

        [HttpGet("{id}")]
        public async Task<SystemReport> Get(string id) {
            return await _systemReportRepository.GetSystemReport(id) ?? new SystemReport();
        }

        [HttpPost]
        public void Post([FromBody] SystemReportParam newSystemReport) {
            _systemReportRepository.AddSystemReport(new SystemReport
            {
                //TODO: Need to autogenerate Report IDs for each team/system.
                Id = newSystemReport.ReportID,
                
            })
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using LHMS.SystemReports.Services;
using System.Collections.Generic;
using LHMS.SystemReports.Models.SystemReportStatus;
using System.Threading.Tasks;

namespace LHMS.SystemReports.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemReportStatusController : ControllerBase
    {
        private readonly ISystemReportStatusService _systemReportStatusService;

        public SystemReportStatusController(ISystemReportStatusService systemReportStatusService)
        {
            _systemReportStatusService = systemReportStatusService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<SystemReportStatusResponse>>> GetAll()
        {
            var systemReportStatuses = await _systemReportStatusService.GetAllSystemReportStatuses();
            if (systemReportStatuses != null)
                return Ok(systemReportStatuses);

            return BadRequest();
        }
    }
}
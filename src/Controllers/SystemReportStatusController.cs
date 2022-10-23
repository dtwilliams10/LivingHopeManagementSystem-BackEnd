using Microsoft.AspNetCore.Mvc;
using LHMS.SystemReports.Services;
using System.Collections.Generic;
using LHMS.SystemReports.Models.SystemReportStatus;

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
        public ActionResult<IEnumerable<SystemReportStatusResponse>> GetAll()
        {
            var systemReportStatuses = _systemReportStatusService.GetAllSystemReportStatuses();
            return Ok(systemReportStatuses);
        }
    }
}
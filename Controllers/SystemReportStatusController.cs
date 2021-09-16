using Microsoft.AspNetCore.Mvc;
using LHMS.SystemReports.Services;
using LHMS.SystemReports.Models;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<SystemReportStatus>> GetAll()
        {
            var systemReportStatuses = _systemReportStatusService.GetAllSystemReportStatuses();
            return Ok(systemReportStatuses);
        }
    }
}
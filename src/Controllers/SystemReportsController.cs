using LHMS.SystemReports.Models.SystemReport;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LHMS.SystemReports.Services;
//using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

//TODO: NEED TO ADD AUTHORIZATION BACK TO THIS CONTROLLER
namespace LHMS.SystemReportsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemReportsController : ControllerBase
    {
        private readonly ISystemReportService _systemReportService;

        public SystemReportsController(ISystemReportService systemReportService)
        {
            _systemReportService = systemReportService;
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<SystemReportResponse>> GetAll()
        {
            var systemReports = _systemReportService.GetAllSystemReports();
            return Ok(systemReports);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<SystemReportResponse> GetById(int id)
        {
            var systemReport = _systemReportService.GetByID(id);
            return Ok(systemReport);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Update(int id, [FromBody] SystemReportRequest systemReport)
        {
            var _systemReport = await _systemReportService.Update(systemReport);
            if (_systemReport is not null)
                return Ok(_systemReport);

            return BadRequest();
        }

        [HttpPost]
        //[Authorize]
        [Consumes("application/json")]
        public async Task<ActionResult> Create(SystemReportRequest systemReport)
        {
            var createdReport = await _systemReportService.Create(systemReport);
            if (createdReport is not null)
                return Ok(createdReport);

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public ActionResult Delete(int id)
        {
            _systemReportService.Delete(id);
            return Ok();
        }
    }
}

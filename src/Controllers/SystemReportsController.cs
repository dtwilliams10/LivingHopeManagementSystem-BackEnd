using LHMS.SystemReports.Models.SystemReport;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LHMS.SystemReports.Services;
using Microsoft.AspNetCore.Authorization;

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

        // GET: api/SystemReport
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<SystemReportResponse>> GetAll()
        {
            var systemReports = _systemReportService.GetAllSystemReports();
            return Ok(systemReports);
        }
        // GET: api/SystemReport/5
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<SystemReportResponse> GetById(int id)
        {
            var systemReport = _systemReportService.GetByID(id);
            return Ok(systemReport);
        }

        // PUT: api/SystemReport/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<SystemReportResponse> Update(int id, SystemReportRequest systemReport)
        {

            var _systemReport = _systemReportService.Update(systemReport);
            return Ok(_systemReport);
        }

        // POST: api/SystemReport
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize]
        [Consumes("application/json")]
        public ActionResult Create(SystemReportRequest systemReport)
        {
            _systemReportService.Create(systemReport);
            return Ok();
        }

        // DELETE: api/SystemReport/5
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public ActionResult Delete(int id)
        {
            _systemReportService.Delete(id);
            return Ok();
        }
    }
}

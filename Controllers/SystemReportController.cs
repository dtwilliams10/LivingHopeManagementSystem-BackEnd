using LHMS.SystemReports.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LHMS.SystemReports.Services;
using Microsoft.AspNetCore.Http;

//TODO: NEED TO ADD AUTHORIZATION BACK TO THIS CONTROLLER
namespace LHMS.SystemReportsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemReportController : ControllerBase
    {
        private readonly ISystemReportService _systemReportService;

        public SystemReportController(ISystemReportService systemReportService)
        {
            _systemReportService = systemReportService;
        }

        // GET: api/SystemReport
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<IEnumerable<SystemReport>> GetAll()
        {
            var systemReports = _systemReportService.GetAllSystemReports();
            return Ok(systemReports);
        }
        // GET: api/SystemReport/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<SystemReport> GetById(int id)
        {
            var systemReport = _systemReportService.GetByID(id);
            return Ok(systemReport);
        }

        // PUT: api/SystemReport/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<SystemReport> Update(int id, SystemReport systemReport)
        {

            var _systemReport = _systemReportService.Update(id, systemReport);
            return Ok(_systemReport);
        }

        // POST: api/SystemReport
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult Create(SystemReport systemReport)
        {
            _systemReportService.Create(systemReport);
            return Ok();
        }

        // DELETE: api/SystemReport/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _systemReportService.Delete(id);
            return Ok();
        }
    }
}

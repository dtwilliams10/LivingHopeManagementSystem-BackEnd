using LHMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LHMSAPI.Helpers;
using LHMSAPI.Services;

//TODO: NEED TO ADD AUTHORIZATION BACK TO THIS CONTROLLER
namespace LHMSAPI.Controllers
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
        public ActionResult<IEnumerable<SystemReport>> GetAllSystemReports()
        {
            var systemReports = _systemReportService.GetAllSystemReports();
            return Ok(systemReports);
        }
        // GET: api/SystemReport/5
        [HttpGet("{id}")]
        public ActionResult<SystemReport> GetSystemReportById(int id)
        {
            var systemReport = _systemReportService.GetByID(id);
            return Ok(systemReport);

            /*
            SystemReport systemReport = await _context.SystemReports.FindAsync(id);

            if (systemReport == null)
            {
                return NotFound();
            }

            return systemReport;*/
        }

        // PUT: api/SystemReport/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public ActionResult<SystemReport> UpdateSystemReport(int id, SystemReport systemReport)
        {

            var _systemReport = _systemReportService.Update(id, systemReport);
            return Ok(_systemReport);
            /*
            if (id != systemReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            */
        }

        // POST: api/SystemReport
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<SystemReport> PostSystemReport(SystemReport systemReport)
        {
            var _systemReport = _systemReportService.Create(systemReport);
            return Ok(_systemReport);
        }

        // DELETE: api/SystemReport/5
        [HttpDelete("{id}")]
        public ActionResult DeleteSystemReport(int id)
        {
            _systemReportService.Delete(id);
            return Ok();
            /*
            SystemReport systemReport = await _context.SystemReports.FindAsync(id);
            if (systemReport == null)
            {
                return NotFound();
            }

            _context.SystemReports.Remove(systemReport);
            await _context.SaveChangesAsync();

            return systemReport;
            */
        }

        /*
        private bool SystemReportExists(int id)
        {
            return _context.SystemReports.Any(e => e.Id == id);
        }
        */
    }
}

using LHMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LHMSAPI.Helpers;

namespace LHMSAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemReportController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SystemReportController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SystemReport
        [HttpGet]
        [Produces("application/json")]

        public async Task<ActionResult<IEnumerable<SystemReport>>> GetSystemReport()
        {
            List<SystemReport> SystemReports = await _context.SystemReports.Where(s => s.Active == true).Include(name => name.SystemName).Include(status => status.SystemReportStatus).AsNoTracking().ToListAsync();
            foreach(SystemReport sr in SystemReports)
            {
               sr.SystemName.Name = _context.SystemName.Find(sr.SystemNameId).Name.ToString();
               sr.SystemReportStatus.Status = _context.SystemStatus.Find(sr.SystemReportStatusId).Status.ToString();
            }
            return SystemReports;
        }
        // GET: api/SystemReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemReport>> GetSystemReport(int id)
        {
            SystemReport systemReport = await _context.SystemReports.FindAsync(id);

            if (systemReport == null)
            {
                return NotFound();
            }

            return systemReport;
        }

        // PUT: api/SystemReport/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemReport(int id, SystemReport systemReport)
        {
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
        }

        // POST: api/SystemReport
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<SystemReport>> PostSystemReport(SystemReport systemReport)
        {
            ///TODO: Need to move this into its own repo file and finish calls that way.
            systemReport.Active = true;
            _context.SystemReports.Add(systemReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemReport", new { id = systemReport.Id }, systemReport);
        }

        // DELETE: api/SystemReport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SystemReport>> DeleteSystemReport(int id)
        {
            SystemReport systemReport = await _context.SystemReports.FindAsync(id);
            if (systemReport == null)
            {
                return NotFound();
            }

            _context.SystemReports.Remove(systemReport);
            await _context.SaveChangesAsync();

            return systemReport;
        }

        private bool SystemReportExists(int id)
        {
            return _context.SystemReports.Any(e => e.Id == id);
        }
    }
}

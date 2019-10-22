using LHMSAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LHMSAPI.Controllers
{
    ///TODO: Need to remove this and fix CORS properly
    [DisableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class SystemReportController : ControllerBase
    {
        private readonly SystemReportContext _context;

        public SystemReportController(SystemReportContext context)
        {
            _context = context;
        }

        // GET: api/SystemReport
        [HttpGet]
        [Produces("application/json")]

        public async Task<ActionResult<IEnumerable<SystemReport>>> GetSystemReport()
        {
            return await _context.SystemReport.ToListAsync();
        }

        // GET: api/SystemReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemReport>> GetSystemReport(int id)
        {
            var systemReport = await _context.SystemReport.FindAsync(id);

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
            _context.SystemReport.Add(systemReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemReport", new { id = systemReport.Id }, systemReport);
        }

        // DELETE: api/SystemReport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SystemReport>> DeleteSystemReport(int id)
        {
            var systemReport = await _context.SystemReport.FindAsync(id);
            if (systemReport == null)
            {
                return NotFound();
            }

            _context.SystemReport.Remove(systemReport);
            await _context.SaveChangesAsync();

            return systemReport;
        }

        private bool SystemReportExists(int id)
        {
            return _context.SystemReport.Any(e => e.Id == id);
        }
    }
}

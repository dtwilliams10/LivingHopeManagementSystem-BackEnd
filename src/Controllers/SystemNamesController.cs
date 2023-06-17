using LHMS.SystemReports.Models.SystemReport;
using LHMS.SystemReports.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LHMS.SystemReports.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SystemNamesController : ControllerBase
    {
        private readonly ISystemNameService _systemNameService;

        public SystemNamesController(ISystemNameService systemNameService)
        {
            _systemNameService = systemNameService;
        }

        [HttpGet("GetAllSystemNames")]
        [Produces("application/json")]
        public async Task<ActionResult<List<SystemNameResponse>>> GetAllSystemNames()
        {
            var systemNames = await _systemNameService.GetAllSystemNames();
            if (systemNames != null)
                return Ok(systemNames);

            return BadRequest();
        }

        [HttpGet("GetSystemNameById/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<List<SystemNameResponse>>> GetSystemNameById(int id)
        {
            var systemName = await _systemNameService.GetSystemNameById(id);
            if (systemName != null)
                return Ok(systemName);

            return BadRequest();
        }
    }
}
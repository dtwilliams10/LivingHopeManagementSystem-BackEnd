using System.Threading.Tasks;
using LHMS.SystemReports.Services;
using Microsoft.AspNetCore.Mvc;

namespace LHMS.SystemReports.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        /// <summary>
        /// Gets the database status.
        /// </summary>
        [HttpGet]
        public Task<string> GetDatabaseStatus()
        {
            return _statusService.getDatabaseStatus();
        }
    }
}
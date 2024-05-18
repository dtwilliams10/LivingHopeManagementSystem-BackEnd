using System.Threading.Tasks;
using LHMS.SystemReports.Services;
using Microsoft.AspNetCore.Mvc;

namespace LHMS.SystemReports.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController(IStatusService statusService) : ControllerBase
    {

        private readonly IStatusService _statusService = statusService;

        [HttpGet]
        public async Task<string> GetDatabaseStatus()
        {
            var response = await _statusService.getDatabaseStatus();

            return response;
        }
    }
}
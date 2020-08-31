using System.Threading.Tasks;
using LHMSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LHMSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet(Name = "GetDatabaseStatus")]
        public async Task<string> GetDatabaseStatus()
        {
            string response = await _statusService.getDatabaseStatus();

            return response;
        }
    }
}
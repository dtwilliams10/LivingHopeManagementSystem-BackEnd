using System.Threading.Tasks;
using LHMSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LHMSAPI.Controllers
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

        [HttpGet]
        public Task<string> GetDatabaseStatus()
        {
            var response = _statusService.getDatabaseStatus();

            return response;
        }
    }
}
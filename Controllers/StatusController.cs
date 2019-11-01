using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LHMSAPI.Repository;

namespace LHMSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly StatusRepository _statusRepository;

        public StatusController(StatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet(Name = "GetDatabaseStatus")]
        public async Task<string> GetDatabaseStatus()
        {
            string response = await _statusRepository.GetDatabaseStatus();

            return response;
        }
    }
}
using System.Threading.Tasks;
using LHMSAPI.Repository;
using Microsoft.AspNetCore.Mvc;

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
            return await _statusRepository.GetDatabaseStatus();
        }
    }
}
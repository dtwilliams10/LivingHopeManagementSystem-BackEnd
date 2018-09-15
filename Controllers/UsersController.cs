using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LHMSAPI.Models;
using System.Threading.Tasks;
using LHMSAPI.Infrastructure;

namespace lhmsapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository) {
            _usersRepository = usersRepository;
        }
        
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _usersRepository.GetAllUsers();
        }

        /*[HttpGet]
        public ActionResult<IEnumerable<User>> List()
        {
            // in real life - retrieve from database
            var users = new List<User> {
                new User {
                    Id = 1,
                    Name = "Tyler Williams",
                    Summary = "28 / Lead Software Developer"
                },
                new User {
                    Id = 2,
                    Name= "Jessie Williams",
                    Summary = "26 / Most Awesome"
                },
                new User {
                    Id = 3,
                    Name = "Truett Williams",
                    Summary = "Almost 2 / Almost as awesome as Momma"
                }
            }; 

            return Ok(users);
        }*/
    }
}
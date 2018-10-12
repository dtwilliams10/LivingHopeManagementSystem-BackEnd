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
        /*public async Task<IEnumerable<User>> GetUsers()
        {
            return await _usersRepository.GetAllUsers();
        }*/

        [HttpGet]
        public ActionResult<IEnumerable<User>> List()
        {
            // in real life - retrieve from database
            var users = new List<User> {
                new User {
                    id = 1,
                    name = "Tyler Williams",
                    summary = "28 / Lead Software Developer"
                },
                new User {
                    id = 2,
                    name= "Jessie Williams",
                    summary = "26 / Most Awesome"
                },
                new User {
                    id = 3,
                    name = "Truett Williams",
                    summary = "Almost 2 / Almost as awesome as Momma"
                }
            }; 

            return Ok(users);
        }
    }
}
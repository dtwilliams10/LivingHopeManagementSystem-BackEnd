using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace lhmsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> List()
        {
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
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Summary { get; set; }
        }
    }
}
using System;
using LHMSAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHMSAPI.Controllers
{   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public StatusController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public string GetDatabaseStatus()
        {
           return _databaseContext.GetDatabaseStatus();
        }
    }
}
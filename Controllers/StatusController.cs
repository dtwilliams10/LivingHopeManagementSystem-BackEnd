using LHMSAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;

namespace LHMSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly DatabaseContext _dbcontext;

        public StatusController(DatabaseContext context)
        {
            _dbcontext = context;
        }
        [HttpGet(Name = "GetDatabaseStatus")]
        public string GetDatabaseStatus()
        {
            string status;

            try
            {
                //Need to refactor this out and use the appSettings.json file. 
                var conn = new NpgsqlConnection("Server=localhost;Port=54320;Database=LHMS;User Id=postgres;Password=postgres;");
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT version();", conn))
                {
                    int version = cmd.ExecuteNonQuery();

                    Console.WriteLine("Version returned as: {0}", version);

                    if (version > 0)
                    {
                        status = "Database connection successful";
                    }
                    else
                    {
                        status = "Database connection failed";
                    }
                    conn.Close();

                    return status;
                }
            }
            catch
            {
                //refactor to return an error status code. 
                /*  https://docs.microsoft.com/en-us/aspnet/core/web-api/index?view=aspnetcore-2.2  */
                return StatusCode(201).ToString();
            }
        }
    }
}
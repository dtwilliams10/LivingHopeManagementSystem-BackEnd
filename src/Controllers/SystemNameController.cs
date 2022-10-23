using LHMS.SystemReports.Models.SystemReport;
using LHMS.SystemReports.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LHMS.SystemReports.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SystemNameController : ControllerBase
    {
        private readonly ISystemNameService _systemNameService;

        public SystemNameController(ISystemNameService systemNameService)
        {
            _systemNameService = systemNameService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SystemNameResponse>> GetAll()
        {
            var systemNames = _systemNameService.GetAllSystemNames();
            return Ok(systemNames);
        }
    }
}
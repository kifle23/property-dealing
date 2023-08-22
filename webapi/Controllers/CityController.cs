using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public CityController()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<string>> GetTModels()
        {
            return new string[] {"Atlanta", "New York", "Chicago" };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
//using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DBContext context;
        public CityController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<IActionResult>> GetTModels()
        {
            return Ok(context.Cities.ToList());
        }
    }
}
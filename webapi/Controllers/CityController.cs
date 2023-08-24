using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetTModels()
        {
            var cities = await context.Cities.ToListAsync();
            return Ok(cities);
        }
    }
}
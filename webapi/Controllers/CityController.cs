using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;
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

        // GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await context.Cities.ToListAsync();
            return Ok(cities);
        }

        // POST api/city/add?cityName=cityName
        // POST api/city/add/cityName
        [HttpPost("add")]
        [HttpPost("add/{cityName}")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            var city = new City();
            city.Name = cityName;
            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
            return Ok(city);
        }

    
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
            return Ok(city);
        }
    }
}
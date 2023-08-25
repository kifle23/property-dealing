using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Data.Repo;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        // GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        // POST api/city/post
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            await cityRepository.AddCityAsync(city);
            await cityRepository.SaveAsync();
            return StatusCode(201);
        }

        // DELETE api/city/delete/1
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            await cityRepository.DeleteCityAsync(id);
            await cityRepository.SaveAsync();
            return Ok(id);
        }
    }
}
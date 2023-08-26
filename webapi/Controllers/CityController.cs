using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityController(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        // GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _unitOfWork.CityRepository.GetCitiesAsync();

            var citiesDto = from c in cities
                            select new CityDto()    
                            {
                                Id = c.Id,
                                Name = c.Name
                            };
            return Ok(citiesDto);
        }

        // POST api/city/post
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = new City
            {
                Name = cityDto.Name,
                LastUpdatedOn = DateTime.Now,
                LastUpdatedBy = 1
            };
            _unitOfWork.CityRepository.AddCityAsync(city);
            await _unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        // DELETE api/city/delete/1
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            _unitOfWork.CityRepository.DeleteCityAsync(id);
            await _unitOfWork.SaveAsync();
            return Ok(id);
        }
    }
}
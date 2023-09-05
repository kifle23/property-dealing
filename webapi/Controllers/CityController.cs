using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{

    public class CityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            this._unitOfWork = _unitOfWork;
            this.mapper = mapper;
        }

        // GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _unitOfWork.CityRepository.GetCitiesAsync();
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);

            return Ok(citiesDto);
        }

        // POST api/city/post
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedOn = DateTime.Now;
            city.LastUpdatedBy = 1;

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

        // PUT api/city/update/1
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            var city = await _unitOfWork.CityRepository.FindCity(id);
            if (city == null)
            {
                return NotFound();
            }

            mapper.Map(cityDto, city);
            city.LastUpdatedOn = DateTime.Now;
            city.LastUpdatedBy = 1;
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }

        // PUT api/city/update/1
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var city = await _unitOfWork.CityRepository.FindCity(id);
            if (city == null)
            {
                return NotFound();
            }

            cityToPatch.ApplyTo(city, ModelState);
            city.LastUpdatedOn = DateTime.Now;
            city.LastUpdatedBy = 1;
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }

        // PUT api/city/update/1
        [HttpPut("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
        {
            var city = await _unitOfWork.CityRepository.FindCity(id);
            if (city == null)
            {
                return NotFound();
            }

            mapper.Map(cityDto, city);
            city.LastUpdatedOn = DateTime.Now;
            city.LastUpdatedBy = 1;
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }

    }
}
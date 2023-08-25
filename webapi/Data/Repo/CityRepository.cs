using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DBContext context;

        public CityRepository(DBContext context)
        {
            this.context = context;
        }
        public void AddCityAsync(City city)
        {
            context.Cities.AddAsync(city);
        }

        public void DeleteCityAsync(int id)
        {
            var city = context.Cities.Find(id);
            if (city != null)
            {
                context.Cities.Remove(city);
            }
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await context.Cities.ToListAsync();
        }
    }
}
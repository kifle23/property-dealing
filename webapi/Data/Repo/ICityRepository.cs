using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Data.Repo
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> AddCityAsync(City city);
        Task<City> DeleteCityAsync(int id);
        Task<bool> SaveAsync();

    }
}
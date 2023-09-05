using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Data.Repo;
using webapi.Interfaces;

namespace webapi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext context;
        public UnitOfWork(DBContext context)
        {
            this.context = context;

        }
        public ICityRepository CityRepository => new CityRepository(context);

        public IUserRepository UserRepository => new UserRepository(context);

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
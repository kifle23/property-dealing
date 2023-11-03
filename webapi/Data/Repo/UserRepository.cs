using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        public DBContext Context { get; }
        public UserRepository(DBContext context)
        {
            this.Context = context;            
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
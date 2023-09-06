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
            return await Context.Users.FirstOrDefaultAsync(x => x.Username == username
            // && x.Password == password
            );
        }

        public void Register(string username, string password)
        {
            byte[] passwordHash, passwordKey;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            var user = new User
            {
                Username = username,
                Password = passwordHash,
                PasswordKey = passwordKey
            };

            Context.Users.Add(user);
        }

        public async Task<bool> UserExists(string username)
        {
            return await Context.Users.AnyAsync(x => x.Username == username);
        }
    }
}
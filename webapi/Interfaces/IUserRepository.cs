using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);

        void Register(string username, string password);

        Task<bool> UserExists(string username);
    }
}
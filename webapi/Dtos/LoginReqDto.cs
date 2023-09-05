using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Dtos
{
    public class LoginReqDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
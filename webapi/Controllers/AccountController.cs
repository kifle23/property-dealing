using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;

namespace webapi.Controllers
{
    public class AccountController : BaseController
    {
        public IUnitOfWork UnitOfWork { get; }
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;

        }

        // POST api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto user)
        {
            var result = await UnitOfWork.UserRepository.Authenticate(user.Username, user.Password);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
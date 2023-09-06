using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Models;

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

            var loginRes = new LoginResDto
            {
                Username = result.Username,
                Token = GenerateToken(result)
            };
            return Ok(loginRes);
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("super secret key"));
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
             };
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "issuer",
                Audience = "audience",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
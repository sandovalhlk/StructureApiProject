﻿using AppInventario.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;
using System;

namespace AppInventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(UserLogin login) {

            if (IsValidUSer(login)) {
                var token = GenerateToken();
                return Ok(new { token }); 
            }

            return NotFound();
        }

        private bool IsValidUSer(UserLogin login) {
            return true;
        }

        private string GenerateToken() {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //claims
            var claims = new[]
            {
            new Claim(ClaimTypes.Name,"Allan Sandoval"),
            new Claim(ClaimTypes.Email,"Allan Sandoval"),
            new Claim(ClaimTypes.Role,"Allan Sandoval")
            };

            //PayLoad
            var payLoad = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            ) ;

            var token = new JwtSecurityToken(header,payLoad);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

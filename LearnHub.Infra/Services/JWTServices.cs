using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using LearnHub.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearnHub.Infra.Services
{
    public class JWTServices : IJWTServices
    {
        private readonly IJWTRepository iJWTRepository;
        public JWTServices(IJWTRepository iJWTRepository)
        {
            this.iJWTRepository = iJWTRepository;
        }
        public string Auth(Login login)
        {
            var result = iJWTRepository.Auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is api lecture Day@14"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.Username),
                        new Claim(ClaimTypes.Role, result.Roleid.ToString())
                    };

                var tokeOptions = new JwtSecurityToken
                    (
                     claims: claims,
                     expires: DateTime.Now.AddSeconds(10),
                     signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            
            }
        }
    }
}

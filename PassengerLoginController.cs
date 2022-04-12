using BusPassGenerator.Model;
using Local_Bus_Library;
using Local_Bus_Library.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusPassGenerator.Controllers
{
    [Route("api/passengerlogin")]
    [ApiController]
    public class PassengerLoginController : ControllerBase
    {
        PassContext passContext = new PassContext();
        [HttpPost]
        public IActionResult Post(AuthModel auth)
        {
            var u = passContext.PassengerProfile.FirstOrDefault(d => d.AadharId ==auth.Username  && d.Password == auth.Password);
            if (u != null)
            {
                var jwtToken = GenerateToken(u.AadharId);
                return Ok(jwtToken);
            }
            else
                return Unauthorized("Login Failed");
        }
        private string GenerateToken(string username)
        {
            string jwtToken = string.Empty;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Local Bus Pass Generator system for Pune City"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            
            var token = new JwtSecurityToken("localbuspassgenerator.com"
                                            , "localbuspassgenerator.com"
                                            , claims
                                            , expires: DateTime.Now.AddDays(7)
                                            , signingCredentials: credentials);


            jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;

        }
    }
}

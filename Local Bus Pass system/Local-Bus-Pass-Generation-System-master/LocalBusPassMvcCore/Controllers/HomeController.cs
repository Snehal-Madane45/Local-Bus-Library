
using LocalBussPassLibrary.Comman;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace LocalBusPassMvcCore.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        RestClient client = new RestClient("http://localhost:13790/api");
        [HttpGet]
        public IActionResult Index()
        {
            string token = GetCookie();
            var passengerId = JwtUtils.ValidateToken(token);
            if (passengerId == null)
                Response.Redirect("/userlogin");
            return View();
        }



        public string GetCookie()
        {
            return Request.Cookies["Token"];
        }

        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("Local Bus Pass Generator system for Pune City");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}


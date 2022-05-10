using LocalBusPassWebApi.Model;
using LocalBussPassLibrary.Common;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LocalBusPassMvcCore.Controllers
{
    [Route("userlogin")]
    public class UserLoginController : Controller
    {
        RestClient client = new RestClient("http://localhost:13790/api");

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AuthModel authRequest)
        {
            RestRequest request = new RestRequest("/passengerlogin", Method.Post);
            request.AddJsonBody(authRequest);

            var response = await client.ExecutePostAsync<AuthResponse>(request, CancellationToken.None);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                AuthResponse authResponse = response.Data;
                Response.Cookies.Append("Token", authResponse.token);
                Response.Cookies.Append("UserId", authResponse.passengerId.ToString());

                Response.Redirect("/");
            }
            else
            {
                ViewBag.Error = "Username or Password is incorrect";
            }

            return View();
        }
    }
}

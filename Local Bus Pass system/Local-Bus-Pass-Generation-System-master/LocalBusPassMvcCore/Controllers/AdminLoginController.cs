using LocalBusPassWebApi.Model;
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
    [Route("adminlogin")]
    public class AdminLoginController : Controller
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
            RestRequest request = new RestRequest("/adminlogin", Method.Post);
            request.AddJsonBody(authRequest);

            RestResponse response = await client.ExecutePostAsync(request, CancellationToken.None);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Response.Cookies.Append("Token", response.Content);

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

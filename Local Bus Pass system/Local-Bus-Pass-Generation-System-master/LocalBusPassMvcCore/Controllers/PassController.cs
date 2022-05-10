using LocalBussPassLibrary.Entities;
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
    [Route("pass")]
    public class PassController : Controller
    {
        RestClient client = new RestClient("http://localhost:13790/api");
        public IActionResult Index()
        {
            return View();
        }

        [Route("createpass")]
        [HttpGet]
        public IActionResult PassengerView()
        {
            return View("createpass");
        }

        [Route("createpass")]
        [HttpPost]
        public async Task<IActionResult> PassCreation(PassDetails pass)
        {
            string passenderId = Request.Cookies["UserId"];
            RestRequest request = new RestRequest("/createpass/" + passenderId, Method.Post);
            request.AddJsonBody(pass);

            RestResponse response = await client.ExecutePostAsync(request, CancellationToken.None);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "Pass Creation Successful!";
                return View("Confirmation");
            }
            ViewBag.Error = "You have already created Pass";
            return View("Confirmation");
        }

    }
}

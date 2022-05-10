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
    [Route("registration")]
    public class RegistrationController : Controller
    {
        RestClient client = new RestClient("http://localhost:13790/api");
        public IActionResult Index()
        {
            return View();
        }

        [Route("passenger")]
        [HttpGet]
        public IActionResult PassengerView()
        {
            return View("Passenger");
        }

        [Route("admin")]
        [HttpGet]
        public IActionResult AdminView()
        {
            return View("Admin");
        }

        [Route("passenger")]
        [HttpPost]
        public async Task<IActionResult> PassengerRegistration(Passenger passenger)
        {
            RestRequest request = new RestRequest("/passenger", Method.Post);
            request.AddJsonBody(passenger);

            RestResponse response = await client.ExecutePostAsync(request, CancellationToken.None);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "Registration Successful!";
                return View("Success");
            }
            ViewBag.Error = response.ErrorMessage;
            return View("Passenger");
        }

        [Route("admin")]
        [HttpPost]
        public async Task<IActionResult> AdminRegistration(AdminDetails adminDetails)
        {
            RestRequest request = new RestRequest("/admin", Method.Post);
            request.AddJsonBody(adminDetails);

            RestResponse response = await client.ExecutePostAsync(request, CancellationToken.None);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "Registration Successful!";
                return View("Success");
            }
            ViewBag.Error = response.ErrorMessage;
            return View("Admin");
        }

    }
}

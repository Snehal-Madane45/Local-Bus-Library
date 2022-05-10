using LocalBussPassLibrary;
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

    [Route("passengerservice")]
    public class PassengerServiceController : Controller
    {
        RestClient client = new RestClient("http://localhost:13790/api");
        public IActionResult Index()
        {
            return View();
        }
        [Route("updatedetails")]
        [HttpGet]
        public IActionResult UpdateDetail()
        {
            return View();
        }

        [Route("viewprofile")]
        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            string passenderId = Request.Cookies["UserId"];
            RestRequest request = new RestRequest("/passenger/" + passenderId, Method.Get);



            Passenger passengers = await client.GetAsync<Passenger>(request, CancellationToken.None);

            return View(passengers);
        }

        [Route("updatedetails")]
        [HttpPost]
        public async Task<IActionResult> UpdateDetail(Passenger passenger)
        {
            RestRequest request = new RestRequest("/passenger/update", Method.Post);
            request.AddJsonBody(passenger);
            RestResponse response = await client.ExecutePostAsync(request, CancellationToken.None);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "Profile Updated Successful!";
                return View("updated");
            }

            return View("updated");


        }



        [Route("viewpass")]
        [HttpGet]
        public async Task<IActionResult> ViewPass()
        {
            string passId = Request.Cookies["UserId"];
            RestRequest request = new RestRequest("/createpass/" + passId, Method.Get);
            PassDetails passDetails = await client.GetAsync<PassDetails>(request, CancellationToken.None);

            return View(passDetails);

        }

    }
}

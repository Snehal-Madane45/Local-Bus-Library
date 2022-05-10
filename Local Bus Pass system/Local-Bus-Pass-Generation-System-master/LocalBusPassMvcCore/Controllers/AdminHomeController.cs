using Local_Bus_Pass_generation_System.Services;
using LocalBussPassLibrary.Common;
using LocalBussPassLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LocalBusPassMvcCore.Controllers
{
    [Route("adminhome")]
    public class AdminHomeController : Controller
    {
        RestClient client = new RestClient("http://localhost:13790/api");
        AdminServices adminServices = new AdminServices();
        public IActionResult Index()
        {
            return View();
        }

        [Route("report")]
        public IActionResult ReportView()
        {
            AdminReport adminreport = new AdminReport();
            adminreport.totalPass = adminServices.GetTotalGeneratedPass();
            adminreport.totalPayment = adminServices.GetTotalPayment();
            return View("Report", adminreport);
        }

        [Route("viewpass")]
        public IActionResult ViewPass()
        {
            return View("PassengerPass");
        }

        [Route("viewpass")]
        [HttpPost]
        public IActionResult ViewPass(PassDetails passDetails)
        {
            passDetails = adminServices.GetPassById(passDetails.PassId);
            if (passDetails == null)
            {
                ViewBag.Error = "Pass not found";
            }
            return View("PassengerPass", passDetails);
        }

        [Route("viewprofile")]
        public IActionResult ViewProfile()
        {
            return View("PassengerProfile");
        }

        [Route("viewprofile")]
        [HttpPost]
        public IActionResult ViewProfile(Passenger passenger)
        {
            passenger = adminServices.GetPassengerById(passenger.PassengerId);
            if (passenger == null)
            {
                ViewBag.Error = "Passenger Not Found";
            }
            return View("PassengerProfile", passenger);
        }


        [Route("getallpass")]
        [HttpGet]

        public async Task<IActionResult> GetAllPass()
        {

            RestRequest request = new RestRequest("/createpass", Method.Get);



            List<PassDetails> passDetails = await client.GetAsync<List<PassDetails>>(request, CancellationToken.None);

            return View(passDetails);
        }

    }
}

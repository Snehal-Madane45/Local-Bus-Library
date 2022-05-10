using Local_Bus_Pass_generation_System.Services;
using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBusPassWebApi.Controllers
{
    [Route("api/createpass")]
    [ApiController]
    public class PassController : ControllerBase
    {
        PassContext passContext = new PassContext();
        GeneratePassService generatePassService = new GeneratePassService();
        PassengerService passengerService = new PassengerService();
        UserPassViewService userPassViewService = new UserPassViewService();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userPassViewService.GetAllPass());
        }

        [HttpGet("{passId}")]
        public IActionResult Get(int passId)
        {
            return Ok(userPassViewService.GetPassById(passId));
        }

        [HttpPost("{passengerId}")]
        public IActionResult AddPassDetails(PassDetails pass, int passengerId)
        {
            var existId = passContext.PassDetails.FirstOrDefault(d => d.Passenger.PassengerId == passengerId);
            if (existId == null)
            {
                Passenger Passenger = passengerService.GetPassenger(passengerId);
                pass.Passenger = Passenger;
                int cost;
                if (pass.PassType == "AC Bus")
                {
                    cost = generatePassService.CalculatePriceForACBus(pass.PassDuration, pass.Passenger.Age);
                }
                else
                {
                    cost = generatePassService.CalculatePriceForNonAc(pass.PassDuration, pass.Passenger.Age);
                }
                pass.Amount = cost;
                pass.ExpiryDate = pass.StartingDate.AddDays(pass.PassDuration);
                pass.IssueDate = DateTime.Now;
                generatePassService.GeneratePass(pass);
                return Ok("Pass Created Successfully!!!");
            }
            else
                return NotFound($"Already Pass Created by this PassengerId:{passengerId}");
        }

        [HttpPut]
        public IActionResult UpdatePassDetails(PassDetails pass)
        {
            var passdetails = passContext.PassDetails.FirstOrDefault(d => d.PassId == pass.PassId);

            if (passdetails != null)
            {
                passdetails.PassType = pass.PassType;
                passdetails.PassDuration = pass.PassDuration;
                passdetails.IssueDate = pass.IssueDate;
                passdetails.StartingDate = pass.StartingDate;
                passdetails.PaymentMode = pass.PaymentMode;

                passContext.PassDetails.Update(passdetails);
                passContext.SaveChanges();
                return Ok(passdetails);
            }
            else
                return NotFound($"No Details found for:{passdetails.PassId}");
        }


    }
}

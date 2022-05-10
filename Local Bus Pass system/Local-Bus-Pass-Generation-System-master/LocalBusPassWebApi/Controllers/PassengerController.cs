using Local_Bus_Pass_generation_System.Services;
using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBusPassWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PassengerController : ControllerBase
    {
        PassContext passContext = new PassContext();
        PassengerService passengerService = new PassengerService();
        [HttpGet("{passengerid}")]
        public IActionResult Get(int passengerid)
        {

            return Ok(passengerService.GetPassenger(passengerid));
        }
        [HttpPost]
        public IActionResult AddPassengerDetails(Passenger passenger)

        {
            passContext.PassengerProfile.Add(passenger);
            passContext.SaveChanges();
            // return Ok(passContext.PassengerProfile);
            return Ok($"Your Passenger Id is :{passenger.PassengerId}");
        }
        [Route("update")]
        [HttpPost]
        public IActionResult UpdatePassengerDetails(Passenger passenger)
        {
            var passengerdetails = passContext.PassengerProfile.FirstOrDefault(d => d.PassengerId == passenger.PassengerId);

            if (passengerdetails != null)
            {
                passengerdetails.Name = passenger.Name;
                passengerdetails.Age = passenger.Age;
                passengerdetails.Email = passenger.Email;
                passengerdetails.Address = passenger.Address;
                passengerdetails.Gender = passenger.Gender;
                passengerdetails.AadharId = passenger.AadharId;
                passengerdetails.MobileNo = passenger.MobileNo;
                passengerdetails.Password = passenger.Password;

                passContext.PassengerProfile.Update(passengerdetails);
                passContext.SaveChanges();
                return Ok(passengerdetails);
            }
            else
                return NotFound($"No Details found for:{passenger.PassengerId}");
        }
        [HttpDelete("{passengerid}")]
        public IActionResult Delete(int passengerid)
        {
            var passengerdetails = passContext.PassengerProfile.FirstOrDefault(d => d.PassengerId == passengerid);

            if (passengerdetails != null)
            {
                passContext.PassengerProfile.Remove(passengerdetails);
                passContext.SaveChanges();
                return Ok("Deleted Successfully!!!");
            }
            else
                return NotFound($"No Details found for:{passengerid}");
        }

    }
}

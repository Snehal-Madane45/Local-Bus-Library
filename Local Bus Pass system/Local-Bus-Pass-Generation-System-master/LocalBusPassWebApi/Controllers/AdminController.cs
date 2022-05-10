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
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        PassContext passContext = new PassContext();
        //public AdminController(PassContext passContext)
        //{
        //    this.passContext = passContext;
        //}
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(passContext.AdminDetails);
        }
        [HttpPost]
        public IActionResult AddAdminDetails(AdminDetails admin)
        {
            passContext.AdminDetails.Add(admin);
            passContext.SaveChanges();
            return Ok(passContext.AdminDetails);
        }
        [HttpPut]
        public IActionResult UpdateAdminDetails(AdminDetails admin)
        {
            var admindetails = passContext.AdminDetails.FirstOrDefault(d => d.AdminId == admin.AdminId);

            if (admindetails != null)
            {
                admindetails.Name = admin.Name;
                admindetails.Email = admin.Email;
                admindetails.Password = admin.Password;
                passContext.AdminDetails.Update(admindetails);
                passContext.SaveChanges();
                return Ok(admindetails);
            }
            else
                return NotFound($"No Details found for:{admin.AdminId}");
        }
        [HttpDelete("{adminid}")]
        public IActionResult Delete(int adminid)
        {
            var admindetails = passContext.AdminDetails.FirstOrDefault(d => d.AdminId == adminid);

            if (admindetails != null)
            {
                passContext.AdminDetails.Remove(admindetails);
                passContext.SaveChanges();
                return Ok("Deleted Successfully!!!");
            }
            else
                return NotFound($"No Details found for:{adminid}");
        }

    }
}

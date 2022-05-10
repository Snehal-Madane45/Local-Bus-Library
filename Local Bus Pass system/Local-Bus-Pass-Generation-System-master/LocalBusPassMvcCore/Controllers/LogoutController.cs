using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBusPassMvcCore.Controllers
{
    [Route("logout")]
    public class LogoutController : Controller
    {
        [HttpGet]
        public void Index()
        {
            Response.Cookies.Delete("Token");
            Response.Redirect("/");
        }
    }
}

using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Services
{
    public class AdminAuthenticationServices
    {
        PassContext passContext;
        public AdminAuthenticationServices()
        {
            passContext = new PassContext();
        }
        public AdminDetails LoginAdmin(String username, String password)
        {
            AdminDetails admin = passContext.AdminDetails.FirstOrDefault(d => d.Email == username && d.Password == password);
            return admin;
        }
    }
}

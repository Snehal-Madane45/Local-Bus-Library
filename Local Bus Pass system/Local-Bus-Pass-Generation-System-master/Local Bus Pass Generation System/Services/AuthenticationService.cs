using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Services
{
    public class AuthenticationService
    {
        PassContext passContext;
        public AuthenticationService()
        {
            passContext = new PassContext();
        }
        public Passenger PassengerLogin(string username, string password)
        {
            Passenger passenger = passContext.PassengerProfile.FirstOrDefault(d => d.AadharId == username && d.Password == password);
            return passenger;
        }
    }
}

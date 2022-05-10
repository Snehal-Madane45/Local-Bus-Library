using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Services
{
    public class AdminServices
    {
        PassContext passContext = new PassContext();

        public AdminDetails RegisterAdmin(AdminDetails adminDetails)
        {
            passContext.AdminDetails.Add(adminDetails);
            passContext.SaveChanges();
            return adminDetails;
        }
        public int GetTotalGeneratedPass()
        {
            int totalPass = passContext.PassDetails.Count();
            return totalPass;
        }

        public float GetTotalPayment()
        {
            float totalpayment = passContext.PassDetails.Sum(d => d.Amount);
            return totalpayment;
        }

        public Passenger GetPassengerById(int passengerId)
        {
            Passenger p = passContext.PassengerProfile.FirstOrDefault(d => d.PassengerId == passengerId);
            return p;
        }

        public PassDetails GetPassById(int passId)
        {
            PassDetails passDetails = passContext.PassDetails.FirstOrDefault(d => d.PassId == passId);
            return passDetails;
        }
    }
}

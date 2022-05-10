using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Services
{
    public class UserPassViewService
    {
        PassContext passContext = new PassContext();
        public PassDetails UserPassView(Passenger passenger)
        {
            PassDetails pass = passContext.PassDetails.FirstOrDefault(d => d.Passenger.PassengerId == passenger.PassengerId);
            return pass;
        }

        public PassDetails GetPassById(int passId)
        {
            PassDetails pass = passContext.PassDetails.Include(m => m.Passenger).FirstOrDefault(d => d.PassId == passId);
            return pass;
        }

        public List<PassDetails> GetAllPass()
        {
            List<PassDetails> pass = passContext.PassDetails.Include(m => m.Passenger).ToList();
            return pass;
        }
    }
}

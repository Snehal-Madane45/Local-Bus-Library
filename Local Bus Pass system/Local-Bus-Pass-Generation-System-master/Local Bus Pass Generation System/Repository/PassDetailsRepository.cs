using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Repositories
{
    public class PassDetailsRepository
    {
        PassContext passContext;
        public PassDetailsRepository()
        {
            passContext = new PassContext();
        }
        public PassDetails AddPassDetails(PassDetails pass)
        {
            passContext.PassDetails.Update(pass);
            passContext.SaveChanges();

            return pass;
        }
    }
}

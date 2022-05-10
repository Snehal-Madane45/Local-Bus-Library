using Local_Bus_Pass_generation_System.Repositories;
using LocalBussPassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Services
{
    public class GeneratePassService
    {
        PassDetailsRepository passDetailsRepository = new PassDetailsRepository();
        public void GeneratePass(PassDetails passDetails)
        {
            passDetailsRepository.AddPassDetails(passDetails);

        }

        public int CalculatePriceForACBus(int duration, int age)
        {
            int cost = 0;
            if (duration == 30)
            {
                cost = 500;
            }
            else if (duration == 60)
            {
                cost = 960;
            }
            else if (duration == 90)
            {
                cost = 1440;
            }
            if (age <= 12 || age >= 60)
            {
                cost = cost / 2;
            }
            return cost;
        }

        public int CalculatePriceForNonAc(int duration, int age)
        {
            int cost = 0;
            if (duration == 30)
            {
                cost = 300;
            }
            else if (duration == 60)
            {
                cost = 560;
            }
            else if (duration == 90)
            {
                cost = 840;
            }
            if (age <= 12 || age >= 60)
            {
                cost = cost / 2;
            }
            return cost;
        }
    }
}

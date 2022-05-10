using Local_Bus_Pass_generation_System.Repositories;
using LocalBussPassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Services
{
    public class PassengerService
    {
        PassengerRepository passengerRepository = new PassengerRepository();
        public Passenger create(Passenger passenger)
        {
            passengerRepository.AddPassenger(passenger);
            return passenger;
        }

        public Passenger GetPassenger(int passengerId)
        {
            Passenger passenger = passengerRepository.GetPasengerById(passengerId);
            return passenger;
        }
    }
}

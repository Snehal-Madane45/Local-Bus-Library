using LocalBussPassLibrary;
using LocalBussPassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Bus_Pass_generation_System.Repositories
{
    public class PassengerRepository
    {
        PassContext passContext;
        public PassengerRepository()
        {
            passContext = new PassContext();
        }
        public Passenger AddPassenger(Passenger passenger)
        {
            if (!passContext.PassengerProfile.Any(d => d.PassengerId == passenger.PassengerId))
            {
                passContext.PassengerProfile.Add(passenger);
                passContext.SaveChanges();
            }
            else
                throw new Exception($"Passenger with the same passenger number {passenger.PassengerId} already exist");
            return passenger;
        }
        public Passenger Update(Passenger passenger)
        {
            passContext.PassengerProfile.Update(passenger);
            passContext.SaveChanges();

            return passenger;
        }
        public void Delete(int passengerId)
        {
            Passenger passenger = passContext.PassengerProfile.FirstOrDefault(d => d.PassengerId == passengerId);
            if (passenger != null)
            {
                passContext.PassengerProfile.Remove(passenger);
                passContext.SaveChanges();
            }
            else
                throw new Exception($"Student with the id: {passengerId} does not exist");

        }

        public Passenger GetPasengerById(int passengerId)
        {
            Passenger passenger = passContext.PassengerProfile.FirstOrDefault(d => d.PassengerId == passengerId);
            return passenger;
        }
    }
}

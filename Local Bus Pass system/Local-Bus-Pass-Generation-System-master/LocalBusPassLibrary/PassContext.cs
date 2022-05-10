using LocalBussPassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocalBussPassLibrary
{
    public class PassContext : DbContext
    {
        public DbSet<Passenger> PassengerProfile { get; set; }
        public DbSet<PassDetails> PassDetails { get; set; }
        public DbSet<AdminDetails> AdminDetails { get; set; }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security = SSPI; Server =DESKTOP-51COMKG\SQLEXPRESS02; DataBase  = BusPassGenrationDb");
        }
    }
}

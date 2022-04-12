using Local_Bus_Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Local_Bus_Library
{
    public class PassContext:DbContext
    {
        public DbSet<Passenger> PassengerProfile { get; set; }
        public DbSet<PassDetails> PassDetails { get; set; }
        public DbSet<AdminDetails> AdminDetails { get; set; }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security = False; Server =.\SQLEXPRESS; DataBase = BusPassGeneratorDb; uid = sa; password = pass@123");
        }
    }
}

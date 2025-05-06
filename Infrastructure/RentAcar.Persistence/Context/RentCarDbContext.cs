using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Context
{
    public class RentCarDbContext :DbContext
    {
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SERHAT\\SQLEXPRESS; Database=RentedCarDb; Trusted_Connection=True; TrustServerCertificate=True;");
        }
        public DbSet<RentedCar> RentedCars { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

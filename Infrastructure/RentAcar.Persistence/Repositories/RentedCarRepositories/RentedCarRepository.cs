using Microsoft.EntityFrameworkCore;
using RentAcar.Persistence.Context;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Repositories.RentedCarRepositories
{
    public class RentedCarRepository : IRentedCarRepository
    {
        private readonly RentCarDbContext _context;

        public RentedCarRepository(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task CreateRentedCarAsync(RentedCar model)
        {
           await _context.RentedCars.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public Task DeleteRentedCarAsync(RentedCar model)
        {
           _context.RentedCars.Remove(model);
            return _context.SaveChangesAsync();
        }

        public async Task<List<RentedCar>> GetAllRentedCarAsync()
        {
            var value = await _context.RentedCars.ToListAsync();
            return value;
        }

        public async Task<RentedCar> GetByIdRentedCarAsync(int id)
        {
           var value= await _context.RentedCars.FindAsync(id);
            return value;
        }

        public async Task UpdateRentedCarsync(RentedCar model)
        {
            _context.RentedCars.Update(model);
           await _context.SaveChangesAsync();
        }
    }
}

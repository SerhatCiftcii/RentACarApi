using Microsoft.EntityFrameworkCore;
using RentAcar.Persistence.Context;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Repositories.CarRepositories
{
    public class CarRepository :ICarRepository
    {
        private readonly RentCarDbContext _context;
        public CarRepository(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task CreateCarAsync(Car entity)
        {
           await _context.Cars.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(Car entity)
        {
             _context.Cars.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            var result=await _context.Cars.ToListAsync();
            return result;
        }

        public async Task<Car> GetByIdCarAsync(int id)
        {
            var result= await _context.Cars.FindAsync(id);
            return result;
        }

        public async Task UpdateCarAsync(Car entity)
        {
            _context.Cars.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

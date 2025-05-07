using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Repositories.CarRepositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetByIdCarAsync(int id); //
        Task CreateCarAsync(Car entity);
        Task UpdateCarAsync(Car entity);
        Task DeleteCarAsync(Car entity); //service tarafında id ile yaptım.
    }
}

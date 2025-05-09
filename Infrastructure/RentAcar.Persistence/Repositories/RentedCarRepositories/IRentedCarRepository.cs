using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Repositories.RentedCarRepositories
{
    public   interface IRentedCarRepository
    {
        Task<List<RentedCar>> GetAllRentedCarAsync();
        Task<RentedCar> GetByIdRentedCarAsync(int id); //
        Task CreateRentedCarAsync(RentedCar model);
        Task UpdateRentedCarsync(RentedCar model);
        Task DeleteRentedCarAsync(RentedCar model); //service tarafında id ile yaptım.
    }
}


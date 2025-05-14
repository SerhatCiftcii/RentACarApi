using RentAcar.Application.Dtos.UserDtos;
using RentAcar.Application.RentedCarDtos;
using RentAcar.Persistence.Repositories.CarRepositories;
using RentAcar.Persistence.Repositories.RentedCarRepositories;
using RentAcar.Persistence.Repositories.UserRepositories;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Application.Services.RentedCarServices
{
    public class RentedCarServices : IRentedCarServices
    {
        private readonly IRentedCarRepository _rentedCarRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICarRepository _carRepository;

        public RentedCarServices(IRentedCarRepository rentedCarRepository, ICarRepository carRepository, IUserRepository userRepository)
        {
            _rentedCarRepository = rentedCarRepository;
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        public async Task CreateRentedCar(CreateRentedCarDto dto)
        {
            var value = new RentedCar
            {
                //Id = dto.Id,
                UserId = dto.UserId,
                CarId = dto.CarId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TotalPrice = dto.TotalPrice,
                DamagePrice = dto.DamagePrice,
                IsCompleted = dto.IsCompleted
            };
            await _rentedCarRepository.CreateRentedCarAsync(value);
        }

        public async Task DeleteRentedCar(int id)
        {
            var value = await _rentedCarRepository.GetByIdRentedCarAsync(id);
           await _rentedCarRepository.DeleteRentedCarAsync(value);
        }

        public async Task<List<ResultRentedCarDto>> GetAllRentedCars()
        {
            var value = await _rentedCarRepository.GetAllRentedCarAsync();
            var users= await _userRepository.GetAllUsersAsync();
            var cars = await _carRepository.GetAllCarsAsync();
           
            var result = new List<ResultRentedCarDto>();
            foreach (var rentedCar in value)
            {
                var user = await _userRepository.GetByIdUserAsync(rentedCar.UserId);
                var car = await _carRepository.GetByIdCarAsync(rentedCar.CarId);
                var newRentedCar = new ResultRentedCarDto
                {
                    Id = rentedCar.Id,
                    UserId = rentedCar.UserId,
                   
                    CarId = rentedCar.CarId,
                    StartDate = rentedCar.StartDate,
                    EndDate = rentedCar.EndDate,
                    TotalPrice = rentedCar.TotalPrice,
                    DamagePrice = rentedCar.DamagePrice,
                    IsCompleted = rentedCar.IsCompleted
                };
                newRentedCar.User = new OnlyInfoUserDto
                { 
                    Id = user.Id,
                    Surname = user.Surname,
                    Role = user.Role,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password
                };
                newRentedCar.Car = car;
                result.Add(newRentedCar);
            }
            return result;

        }

        public async Task<GetByIdRentedCarDto> GetByIdRentedCar(int id)
        {
            var value = await _rentedCarRepository.GetByIdRentedCarAsync(id);
            var result = new GetByIdRentedCarDto
            {
                Id = value.Id,
                UserId = value.UserId,
                CarId = value.CarId,
                StartDate = value.StartDate,
                EndDate = value.EndDate,
                TotalPrice = value.TotalPrice,
                DamagePrice = value.DamagePrice,
                IsCompleted = value.IsCompleted
            };
            return result;
        }

        public async Task UpdateRentedCar(UpdateRentedCarDto dto)
        {
           var value= await _rentedCarRepository.GetByIdRentedCarAsync(dto.Id);
            value.UserId = dto.UserId;
            value.CarId = dto.CarId;
            value.StartDate = dto.StartDate;
            value.EndDate = dto.EndDate;
            value.TotalPrice = dto.TotalPrice;
            value.DamagePrice = dto.DamagePrice;
            value.IsCompleted = dto.IsCompleted;

            await _rentedCarRepository.UpdateRentedCarAsync(value);



        }
    }
}

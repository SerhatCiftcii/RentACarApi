using RentAcar.Application.Dtos.CarDtos;
using RentAcar.Persistence.Repositories.CarRepositories;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Application.Services.CarServices
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository _repository;
        public CarServices(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateCar(CreateCarDto car)
        {
            var value = new Car
            {
                ImageUrl = car.ImageUrl,
                Brand = car.Brand,
                Model = car.Model,
                KM = car.KM,
                Type = car.Type,
                Fuel = car.Fuel,
                DailyPrice = car.DailyPrice,
                IsAvailable = car.IsAvailable,
                Year = car.Year,


            };
            await _repository.CreateCarAsync(value);
        }

        public async Task DeleteCar(int id)
        {
            var value=await _repository.GetByIdCarAsync(id);
            await _repository.DeleteCarAsync(value);

        }

        public async Task<List<ResultCarDto>> GetAllCars()
        {
            var value= await _repository.GetAllCarsAsync();
            var result = value.Select(x=> new ResultCarDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Brand = x.Brand,
                Model = x.Model,
                KM = x.KM,
                Type = x.Type,
                Fuel = x.Fuel,
                DailyPrice = x.DailyPrice,
                IsAvailable = x.IsAvailable,
                Year = x.Year,
            }).ToList();
            return result;
        }

        public async Task<GetByIdCarDto> GetByIdCar(int id)
        {
           var value= await _repository.GetByIdCarAsync(id);
            var result = new GetByIdCarDto
            {
                Id=value.Id,
                ImageUrl=value.ImageUrl,
                Brand=value.Brand,
                Model = value.Model,
                KM = value.KM,
                Type = value.Type,
                Fuel = value.Fuel,
                DailyPrice = value.DailyPrice,
                IsAvailable = value.IsAvailable,
                Year = value.Year,
            };
            return result;
           
        }

        public async Task UpdateCar(UpdateCarDto car)
        {
            var value =  await _repository.GetByIdCarAsync(car.Id);
            value.ImageUrl = car.ImageUrl;
            value.Brand = car.Brand;
            value.Model = car.Model;
            value.KM = car.KM;
            value.Type = car.Type;
            value.Fuel = car.Fuel;
            value.DailyPrice = car.DailyPrice;
            value.IsAvailable = car.IsAvailable;
            value.Year = car.Year;
            await _repository.UpdateCarAsync(value);



        }
    }
}

using RentAcar.Application.Dtos.RentedCarDtos;
using RentAcar.Application.Dtos.UserDtos;
using RentAcar.Persistence.Repositories.CarRepositories;
using RentAcar.Persistence.Repositories.RentedCarRepositories;
using RentAcar.Persistence.Repositories.UserRepositories;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Application.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IRentedCarRepository _rentedCarRepository;
        private readonly ICarRepository _carRepository;
        public UserServices(IUserRepository userRepository, IRentedCarRepository rentedCarRepository, ICarRepository carRepository)
        {
            _userRepository = userRepository;
            _rentedCarRepository = rentedCarRepository;
            _carRepository = carRepository;
        }
        public async Task CreateUser(CreateUserDto dto)
        {
            var value = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password,
                Role = dto.Role,
                RentedCars = new List<RentedCar>(),
            };
            await _userRepository.CreateUserAsync(value);

        }

        public Task DeleteUser(int id)
        {
           var value= _userRepository.GetByIdUserAsync(id);
            return _userRepository.DeleteUserAsync(value.Result);
        }

        public async Task<List<ResultUserDto>> GetAllUsers()
        {
            var value = await _userRepository.GetAllUsersAsync();
            var result = new List<ResultUserDto>();

            foreach (var user in value)
            {
                var newuser = new ResultUserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password,
                    Role = user.Role,
                };

                var userrents = await _rentedCarRepository.GetRentedCarByUserIdAsync(user.Id);
                var onlyinforent = new List<OnlyInfoRentedCarDto>();
                foreach (var userrent in userrents)
                {

                    var newonlyinforent = new OnlyInfoRentedCarDto
                    {
                        Id = userrent.Id,
                        CarId = userrent.CarId,
                        StartDate = userrent.StartDate,
                        EndDate = userrent.EndDate,
                        DamagePrice = userrent.DamagePrice,
                        TotalPrice = userrent.TotalPrice,
                        IsCompleted = userrent.IsCompleted,
                    };
                    newonlyinforent.Car = await _carRepository.GetByIdCarAsync(userrent.CarId);

                    onlyinforent.Add(newonlyinforent);
                }
                newuser.RentedCars = onlyinforent;
                result.Add(newuser);

            }
            return result;
        }
        //chat gpt daha temiz yazım örnek GetAllUsers için
        public async Task<List<ResultUserDto>> GetAllUsersCreateByChatGpt()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var result = new List<ResultUserDto>();

            foreach (var user in users)
            {
                var rentedCars = await _rentedCarRepository.GetRentedCarByUserIdAsync(user.Id);
                var rentedCarDtos = new List<OnlyInfoRentedCarDto>();

                foreach (var rent in rentedCars)
                {
                    var car = await _carRepository.GetByIdCarAsync(rent.CarId);

                    rentedCarDtos.Add(new OnlyInfoRentedCarDto
                    {
                        Id = rent.Id,
                        CarId = rent.CarId,
                        StartDate = rent.StartDate,
                        EndDate = rent.EndDate,
                        DamagePrice = rent.DamagePrice,
                        TotalPrice = rent.TotalPrice,
                        IsCompleted = rent.IsCompleted,
                        Car = car
                    });
                }

                result.Add(new ResultUserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password,
                    Role = user.Role,
                    RentedCars = rentedCarDtos
                });
            }

            return result;
        }



        public async Task<GetByIdUserDto> GetByIdUser(int id)
        {
           var value= await _userRepository.GetByIdUserAsync(id);
            var result = new GetByIdUserDto
            {
                Id = value.Id,
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email,
                Phone = value.Phone,
                Password = value.Password,
                Role = value.Role,
                RentedCars = new List<RentedCar>(),
            };
            return result;
        }

        public async Task UpdateUser(UpdateUserDto dto)
        {
            var value= await _userRepository.GetByIdUserAsync(dto.Id);//biz ir kullanıcı bir id göderiyoruz 
            value.Name = dto.Name;
            value.Surname = dto.Surname;
            value.Email = dto.Email;
            value.Phone = dto.Phone;
            value.Password = dto.Password;
            value.Role = dto.Role;
            await _userRepository.UpdateUserAsync(value);

        }
    }
}

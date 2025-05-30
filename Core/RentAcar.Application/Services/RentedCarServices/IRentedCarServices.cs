﻿using RentAcar.Application.RentedCarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Application.Services.RentedCarServices
{
    public interface IRentedCarServices 
    {
        Task<List<ResultRentedCarDto>> GetAllRentedCars();
        Task<GetByIdRentedCarDto> GetByIdRentedCar(int id);
        Task UpdateRentedCar(UpdateRentedCarDto dto);
        Task CreateRentedCar(CreateRentedCarDto dto);
        Task DeleteRentedCar(int id);

    }
}

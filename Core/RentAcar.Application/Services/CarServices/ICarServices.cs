using RentAcar.Application.Dtos.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Application.Services.CarServices
{
    //arabanın arayuzundeki işlemlerini yapacak olan interface
    public interface ICarServices
    {
        Task<List<ResultCarDto>> GetAllCars();
        Task<GetByIdCarDto> GetByIdCar(int id); //id ile arabanın detaylarını getirecek
        Task CreateCar(CreateCarDto car); //araba ekleyecek
        Task UpdateCar(UpdateCarDto car); //araba güncelleyecek
        Task DeleteCar(int id); //id ile arabayı silecek Repo tarrfında entity göndermiştik ordaki entitydeki id buluyoruz aslında.
    }
}

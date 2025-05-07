using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAcar.Application.Dtos.CarDtos;
using RentAcar.Application.Services.CarServices;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }
        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
         var result= await _carServices.GetAllCars();
         return Ok(result);
        }
        [HttpGet("GetByIdCar")]
        public async Task<IActionResult> GetByIdCar(int id)
        {
            var result = await _carServices.GetByIdCar(id);
            return Ok(result);
        }
        [HttpPost("CreateCar")]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            await _carServices.CreateCar(createCarDto);
            return Ok("Araba Oluşturuldu.");
        }
        [HttpPut("UpdateCar")]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            await _carServices.UpdateCar(updateCarDto);
            return Ok("Araba Güncellendi.");

        }
        [HttpDelete("DeleteCar")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carServices.DeleteCar(id);
            return Ok("Araba Silindi.");
        }
    }

}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAcar.Application.RentedCarDtos;
using RentAcar.Application.Services.RentedCarServices;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedCarsController : ControllerBase
    {
        private readonly IRentedCarServices _rentedCarServices;
            public RentedCarsController(IRentedCarServices rentedCarServices)
        {
            _rentedCarServices = rentedCarServices;
        }
           
        [HttpGet("GetAllRentedCars")]   
        public async Task<IActionResult> GetAllRentedCars()
        {
            var result= await _rentedCarServices.GetAllRentedCars();
            return Ok(result);
        }
        [HttpGet("GetByIdRentedCar/{id}")]
        public async Task<IActionResult> GetByIdRentedCar(int id)
        {
            var result = await _rentedCarServices.GetByIdRentedCar(id);
            return Ok(result);
        }
        [HttpPost("CreateRentedCar")]
        public async Task<IActionResult> CreateRentedCar(CreateRentedCarDto createRentedCarDto)
        {
            await _rentedCarServices.CreateRentedCar(createRentedCarDto);
            return Ok("Kiralanmış Araç Oluşturuldu");
        }
        [HttpPut("UpdateRentedCar")]
        public async Task<IActionResult> UpdateRentedCar(UpdateRentedCarDto updateRentedCarDto)
        {
            await _rentedCarServices.UpdateRentedCar(updateRentedCarDto);
            return Ok("Kiralanmış Araç Güncellendi");
        }
        [HttpDelete("DeleteRentedCar/{id}")]
        public async Task<IActionResult> DeleteRentedCar(int id)
        {
            await _rentedCarServices.DeleteRentedCar(id);
            return Ok("Kiralanmış Araç Silindi");
        }
    }
}

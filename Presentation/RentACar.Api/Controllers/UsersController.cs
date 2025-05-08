using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAcar.Application.Dtos.UserDtos;
using RentAcar.Application.Services.UserServices;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet("gelallUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userServices.GetAllUsers();
            return Ok(result);
        }
        [HttpGet("getByIdUser/{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var result = await _userServices.GetByIdUser(id);
            return Ok(result);
        }
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            await _userServices.CreateUser(user);
            return Ok("Kullanıcı Olusturuldu");
        }
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            await _userServices.UpdateUser(user);
            return Ok("Kullanıcı Güncellendi");
        }

        [HttpDelete("deleteUser/{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userServices.DeleteUser(id);
            return Ok("Kullanıcı Silindi");
        }
    }
}

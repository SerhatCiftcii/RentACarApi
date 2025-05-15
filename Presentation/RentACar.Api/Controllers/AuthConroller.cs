using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAcar.Application.Dtos.AuthDtos;
using RentAcar.Persistence.Services;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthConroller : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthConroller(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto model)
        {
            if(model.Email== "admin@gmail.com" && model.Password == "123")
            {
                var token= _authServices.GenerateToken();
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}

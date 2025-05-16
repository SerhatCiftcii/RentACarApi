using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAcar.Application.Dtos.AuthDtos;
using RentAcar.Application.Services.UserServices;
using RentAcar.Persistence.Services;
using System.Threading.Tasks;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthConroller : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly IUserServices _userServices;

        public AuthConroller(IAuthServices authServices, IUserServices userServices)
        {
            _authServices = authServices;
            _userServices = userServices;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userServices.CheckUser(model);
            if (user != null)
            {
                var token= _authServices.GenerateToken(user.Id.ToString(),user.Role);
                return Ok(new {jwtToken=token});
            }
            return Unauthorized();
        }
    }
}

using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : ControllerBase
    {
        private readonly IUserRepo userService;

        public ManageUserController(IUserRepo repo)
        {
            userService = repo;
        }

        [HttpPost("Login")]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login(UserLoginRequestDTO dto)
        {
            return new ServiceResponse<UserLoginResponseDTO>()
            {
                Value = await userService.Login(dto.UserName, dto.Password)
            };
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = (await userService.GetAll() as List<UserDTO>)!
            };
        }
    }
}

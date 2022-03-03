using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userService;

        public UserController(IUserRepo userBs)
        {
            userService = userBs;
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = (await userService.GetAll(a => a.FirstName=="emin") as List<UserDTO>)!
            };
        }
    }
}

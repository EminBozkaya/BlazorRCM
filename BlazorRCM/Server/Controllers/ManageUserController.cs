using BlazorRCM.Shared.CustomExceptions;
using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ManageUserController : ControllerBase
    {
        private readonly IUserRepo userService;

        public ManageUserController(IUserRepo repo)
        {
            userService = repo;
        }

        [HttpPost("Login")]
        //[AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login(UserLoginRequestDTO dto)
        {
            //ServiceResponse<UserLoginResponseDTO> result = new();
            try
            {
                

                return new ServiceResponse<UserLoginResponseDTO>()
                {
                    Value = await userService.Login(dto.UserName!, dto.Password!)
                };
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpGet("Users")]
        
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = (await userService.GetAll() as List<UserDTO>)!
            };
        }


        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.Create(User)
            };
        }
    }
}

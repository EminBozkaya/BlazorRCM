using BlazorRCM.Server.Infrasructures;
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
        private readonly IUserRepo Repo;

        public ManageUserController(IUserRepo repo)
        {
            Repo = repo;
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
                    Value = await Repo.Login(dto.UserName!, dto.Password!)
                };
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpGet("GetList")]
        
        public async Task<ServiceResponse<List<UserDTO>>> Get()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = (await Repo.GetAll() as List<UserDTO>)!
            };
        }


        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> Create([FromBody] UserDTO dto)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> Update([FromBody] UserDTO dto)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] UserDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

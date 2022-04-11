using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.CustomExceptions;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.DTOs.ViewDTOs;
using BlazorRCM.Shared.ResponseModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ManageUserController : ControllerBase
    {
        private readonly IUserRepo Repo;
        private readonly IValidator<UserDTO> validator;

        public ManageUserController(IUserRepo repo, IValidator<UserDTO> validator)
        {
            Repo = repo;
            this.validator = validator;
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


        //[HttpPost("Create")]
        //public async Task<ServiceResponse<UserDTO>> Create([FromBody] UserDTO dto)
        //{
        //    return new ServiceResponse<UserDTO>()
        //    {
        //        Value = await Repo.Create(dto)
        //    };
        //}

        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> Create([FromBody] UserDTO dto)
        {
            try 
            {
                var value = await Repo.Create(dto);
                return new ServiceResponse<UserDTO>()
                {
                    Value = value
                };
            }
            catch (ValidationException ex) 
            {
                String? errorMessages = " | ";
                string[] errors = ex.Errors.Select(x => x.ErrorMessage).ToArray();
                for (int i = 0; i < errors.Length; i++)
                {
                    errorMessages = errorMessages + errors[i] + " | ";
                }
                return new ServiceResponse<UserDTO>()
                {
                    Success = false,
                    Message = errorMessages
                };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<UserDTO>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }


        //[HttpPost("Create")]
        //public async Task<ServiceResponse<UserDTO>> Create([FromBody] UserDTO dto)
        //{
        //    var validatorResult = validator.Validate(dto);
        //    if (validatorResult.IsValid)
        //    {
        //        return new ServiceResponse<UserDTO>()
        //        {
        //            Value = await Repo.Create(dto)
        //        };
        //    }
        //    else
        //    {
        //        String? errorMessages = " | ";
        //        string[] errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToArray();
        //        for (int i = 0; i < errors.Length; i++)
        //        {
        //            errorMessages = errorMessages +  errors[i] + " | ";
        //        }
        //        return new ServiceResponse<UserDTO>()
        //        {
        //            Success=false,
        //            Message = errorMessages
        //        };
        //    }

        //}

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> Update([FromBody] UserDTO dto)
        {
            try
            {
                var value = await Repo.Update(dto);
                return new ServiceResponse<UserDTO>()
                {
                    Value = value
                };
            }
            catch (ValidationException ex)
            {
                String? errorMessages = " | ";
                string[] errors = ex.Errors.Select(x => x.ErrorMessage).ToArray();
                for (int i = 0; i < errors.Length; i++)
                {
                    errorMessages = errorMessages + errors[i] + " | ";
                }
                return new ServiceResponse<UserDTO>()
                {
                    Success = false,
                    Message = errorMessages
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UserDTO>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        //[HttpPost("Update")]
        //    public async Task<ServiceResponse<UserDTO>> Update([FromBody] UserDTO dto)
        //    {
        //        return new ServiceResponse<UserDTO>()
        //        {
        //            Value = await Repo.Update(dto)
        //        };
        //    }

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

using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorityTypeController : Controller
    {
        private readonly IAuthorityTypeRepo Repo;

        public AuthorityTypeController(IAuthorityTypeRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]

        public async Task<ServiceResponse<List<AuthorityTypeDTO>>> GetAll()
        {
            return new ServiceResponse<List<AuthorityTypeDTO>>()
            {
                Value = (await Repo.GetAll() as List<AuthorityTypeDTO>)!
            };
        }

        //[HttpGet("AuthorityTypes")]

        //public async Task<List<AuthorityTypeDTO>> GetAll()
        //{
        //    //Expression<Func<AuthorityTypeDTO, bool>>? filter = model.filter;
        //    //string[]? includeList = model.includeList;
        //    return (await Repo.GetAll() as List<AuthorityTypeDTO>)!;

        //}


        [HttpPost("Get")]
        public async Task<List<AuthorityTypeDTO>> Get([FromBody] string[] includeList)
        //public async Task<List<AuthorityTypeDTO>> Get([FromBody] FiltersAndIncludesModel<AuthorityTypeDTO> model)
        {
            //Expression<Func<AuthorityTypeDTO, bool>>? filter = model.filter;
            //string[]? includeList = model.includeList;
            //string gelen = model;

            return (await Repo.GetAll(null,includeList) as List<AuthorityTypeDTO>)!;
            //return (await Repo.GetAll(filter, includeList!) as List<AuthorityTypeDTO>)!;
            
        }

        //[HttpPost("AuthorityTypes")]
        //public async Task<ServiceResponse<List<AuthorityTypeDTO>>> Get([FromBody] FiltersAndIncludesModel<AuthorityTypeDTO> model)
        //{
        //    Expression<Func<AuthorityTypeDTO, bool>>? filter = model.filter;
        //    string[]? includeList = model.includeList;

        //    return new ServiceResponse<List<AuthorityTypeDTO>>()
        //    {
        //        Value = await Repo.GetAll(filter, includeList!) as List<AuthorityTypeDTO>
        //    };
        //}


        [HttpPost("Create")]
        public async Task<ServiceResponse<AuthorityTypeDTO>> Create([FromBody] AuthorityTypeDTO dto)
        {
            return new ServiceResponse<AuthorityTypeDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<AuthorityTypeDTO>> Update([FromBody] AuthorityTypeDTO dto)
        {
            return new ServiceResponse<AuthorityTypeDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] AuthorityTypeDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

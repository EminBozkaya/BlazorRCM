using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using RCMServerData.EFContext;
using System.Linq.Expressions;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserBranchAuthorityController : Controller
    {
        private readonly IUserBranchAuthorityRepo Repo;

        public ManageUserBranchAuthorityController(IUserBranchAuthorityRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]

        public async Task<ServiceResponse<List<UserBranchAuthorityDTO>>> GetAll()
        {
            return new ServiceResponse<List<UserBranchAuthorityDTO>>()
            {
                //Value = await Repo.MyList()
                Value = (await Repo.GetAll() as List<UserBranchAuthorityDTO>)!
                //Value = (await Repo.GetAll(x=>x.Id>7) as List<UserBranchAuthorityDTO>)!
                //Value = (await Repo.GetAll(x=>x.Id>7, "User", "Branch", "AuthorityType") as List<UserBranchAuthorityDTO>)!
            };
        }

        //[HttpPost("UserBranchAuthorities")]
        //public async Task<ServiceResponse<List<UserBranchAuthorityDTO>>> Get([FromBody] FiltersAndIncludesModel<UserBranchAuthorityDTO> model)
        //{
        //    string? filterstring = model.filter;
        //    //Expression<Func<UserBranchAuthorityDTO, bool>>? filter = filterstring as (Expression<Func<UserBranchAuthorityDTO, bool>>?);
        //    string[]? includeList = model.includeList;

        //    return new ServiceResponse<List<UserBranchAuthorityDTO>>()
        //    {
        //        Value = await Repo.GetAll(null,includeList!) as List<UserBranchAuthorityDTO>
        //    };
        //}


        [HttpPost("Create")]
        public async Task<ServiceResponse<UserBranchAuthorityDTO>> Create([FromBody] UserBranchAuthorityDTO dto)
        {
            return new ServiceResponse<UserBranchAuthorityDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserBranchAuthorityDTO>> Update([FromBody] UserBranchAuthorityDTO dto)
        {
            return new ServiceResponse<UserBranchAuthorityDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        //[HttpPost("Delete")]
        //public async Task<BaseResponse> Delete([FromBody] UserBranchAuthorityDTO dto)
        //{
        //    await Repo.Delete(dto);
        //    return new BaseResponse();
        //}


        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] UserBranchAuthorityDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

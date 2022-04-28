using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IBranchRepo Repo;

        public BranchController(IBranchRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<ServiceResponse<List<BranchDTO>>> GetAll()
        {
            return new ServiceResponse<List<BranchDTO>>()
            {
                Value = (await Repo.GetAll() as List<BranchDTO>)!
            };
        }


        [HttpPost("Create")]
        public async Task<ServiceResponse<BranchDTO>> Create([FromBody] BranchDTO dto)
        {
            return new ServiceResponse<BranchDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<BranchDTO>> Update([FromBody] BranchDTO dto)
        {
            return new ServiceResponse<BranchDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] BranchDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

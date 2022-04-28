using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.CustomExceptions;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepo Repo;

        public SupplierController(ISupplierRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]
        
        public async Task<ServiceResponse<List<SupplierDTO>>> Get()
        {
            return new ServiceResponse<List<SupplierDTO>>()
            {
                Value = (await Repo.GetAll(null, "User", "Branch") as List<SupplierDTO>)!
            };
        }


        [HttpPost("Create")]
        public async Task<ServiceResponse<SupplierDTO>> Create([FromBody] SupplierDTO dto)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<SupplierDTO>> Update([FromBody] SupplierDTO dto)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] SupplierDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

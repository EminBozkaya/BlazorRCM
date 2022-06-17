using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly ISaleRepo Repo;

        public SaleController(ISaleRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<ServiceResponse<List<SaleDTO>>> GetAll()
        {
            return new ServiceResponse<List<SaleDTO>>()
            {
                Value = (await Repo.GetAll() as List<SaleDTO>)!
            };
        }


        [HttpPost("Create")]
        public async Task<ServiceResponse<SaleDTO>> Create([FromBody] SaleDTO dto)
        {
            return new ServiceResponse<SaleDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<SaleDTO>> Update([FromBody] SaleDTO dto)
        {
            return new ServiceResponse<SaleDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] SaleDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

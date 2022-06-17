using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSaleNoteController : Controller
    {
        private readonly IProductSaleNoteRepo Repo;

        public ProductSaleNoteController(IProductSaleNoteRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<ServiceResponse<List<ProductSaleNoteDTO>>> GetAll()
        {
            return new ServiceResponse<List<ProductSaleNoteDTO>>()
            {
                Value = (await Repo.GetAll() as List<ProductSaleNoteDTO>)!
            };
        }


        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductSaleNoteDTO>> Create([FromBody] ProductSaleNoteDTO dto)
        {
            return new ServiceResponse<ProductSaleNoteDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductSaleNoteDTO>> Update([FromBody] ProductSaleNoteDTO dto)
        {
            return new ServiceResponse<ProductSaleNoteDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] ProductSaleNoteDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

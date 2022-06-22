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
                Value = (await Repo.GetAll() as List<SaleDTO>)!.OrderBy(x=>x.Id).ToList()
            };
        }

        [HttpGet("GetListOfToday")]
        public async Task<ServiceResponse<List<SaleDTO>>> GetAllToday()
        {
            return new ServiceResponse<List<SaleDTO>>()
            {
                Value = (await Repo.GetAll(x=>x.IsEOD==false) as List<SaleDTO>)!.OrderBy(x => x.Id).ToList()
            };
        }

        [HttpPost("GetListOfAnyDay")]
        public async Task<ServiceResponse<List<SaleDTO>>> GetListByDate([FromBody] DateTime date)
        {
            return new ServiceResponse<List<SaleDTO>>()
            {
                Value = (await Repo.GetAll(x => x.EOD == (DateTime)date) as List<SaleDTO>)!.OrderBy(x => x.Id).ToList()
            };
        }

        [HttpPost("GetListOfDateRange")]
        public async Task<ServiceResponse<List<SaleDTO>>> GetListByRange([FromBody] List<DateTime> rangeList)
        {
            return new ServiceResponse<List<SaleDTO>>()
            {
                Value = (await Repo.GetAll(x => x.EOD >= rangeList[0] && x.EOD<= rangeList[1]) as List<SaleDTO>)!.OrderBy(x => x.Id).ToList()
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

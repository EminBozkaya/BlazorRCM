using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageFirmTypeController : Controller
    {
        private readonly IFirmTypeRepo Repo;

        public ManageFirmTypeController(IFirmTypeRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<ServiceResponse<List<FirmTypeDTO>>> GetAll()
        {
            return new ServiceResponse<List<FirmTypeDTO>>()
            {
                Value = (await Repo.GetAll() as List<FirmTypeDTO>)!
            };
        }


        [HttpPost("Create")]
        public async Task<ServiceResponse<FirmTypeDTO>> Create([FromBody] FirmTypeDTO dto)
        {
            return new ServiceResponse<FirmTypeDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<FirmTypeDTO>> Update([FromBody] FirmTypeDTO dto)
        {
            return new ServiceResponse<FirmTypeDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] FirmTypeDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

﻿using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRCM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleDetailController : Controller
    {
        private readonly ISaleDetailRepo Repo;

        public SaleDetailController(ISaleDetailRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<ServiceResponse<List<SaleDetailDTO>>> GetAll()
        {
            return new ServiceResponse<List<SaleDetailDTO>>()
            {
                Value = (await Repo.GetAll() as List<SaleDetailDTO>)!
            };
        }

        [HttpPost("GetListBySaleId")]
        public async Task<ServiceResponse<List<SaleDetailDTO>>> GetAllById([FromBody] int id)
        {
            return new ServiceResponse<List<SaleDetailDTO>>()
            {
                Value = (await Repo.GetAll(x=>x.SId==id) as List<SaleDetailDTO>)!.OrderBy(x => x.BillOrder).ToList()
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<SaleDetailDTO>> Create([FromBody] SaleDetailDTO dto)
        {
            return new ServiceResponse<SaleDetailDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<SaleDetailDTO>> Update([FromBody] SaleDetailDTO dto)
        {
            return new ServiceResponse<SaleDetailDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] SaleDetailDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }

        [HttpPost("DeleteById")]
        public async Task<BaseResponse> DeleteById([FromBody] int SId)
        {
            await Repo.DeleteByFilter(s => s.SId == SId);
            return new BaseResponse();
        }
    }
}

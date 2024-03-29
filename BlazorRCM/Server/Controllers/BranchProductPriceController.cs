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
    public class BranchProductPriceController : Controller
    {
        private readonly IBranchProductPriceRepo Repo;

        public BranchProductPriceController(IBranchProductPriceRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<ServiceResponse<List<BranchProductPriceDTO>>> GetAll()
        {
            return new ServiceResponse<List<BranchProductPriceDTO>>()
            {
                Value = (await Repo.GetAll() as List<BranchProductPriceDTO>)!
            };
        }

        [HttpPost("GetBranchList")]
        public async Task<ServiceResponse<List<BranchProductPriceDTO>>> GetBranchList([FromBody] short BranchId)
        {
            return new ServiceResponse<List<BranchProductPriceDTO>>()
            {
                Value = (await Repo.GetAll(i=>i.BId==BranchId) as List<BranchProductPriceDTO>)!.OrderBy(x => x.PId).ToList()
                //Value = (await Repo.GetAll(i=>i.BId==short.Parse(BranchId)) as List<BranchProductPriceDTO>)!
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<BranchProductPriceDTO>> Create([FromBody] BranchProductPriceDTO dto)
        {
            return new ServiceResponse<BranchProductPriceDTO>()
            {
                Value = await Repo.Create(dto)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<BranchProductPriceDTO>> Update([FromBody] BranchProductPriceDTO dto)
        {
            return new ServiceResponse<BranchProductPriceDTO>()
            {
                Value = await Repo.Update(dto)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> Delete([FromBody] BranchProductPriceDTO dto)
        {
            return new ServiceResponse<bool>()
            {
                Value = await Repo.Delete(dto)
            };
        }
    }
}

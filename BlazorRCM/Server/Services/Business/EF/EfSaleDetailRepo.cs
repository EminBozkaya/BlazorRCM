﻿using AutoMapper;
using BlazorRCM.Server.Services.BaseServices.BaseService.EF;
using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfSaleDetailRepo : EfRepositoryBase<RCMBlazorContext, SaleDetail, SaleDetailDTO>, ISaleDetailRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfSaleDetailRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

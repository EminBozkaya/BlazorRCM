﻿using AutoMapper;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfBranchRepo : EfRepositoryBase<RCMBlazorContext, Branch, BranchDTO>, IBranchRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfBranchRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

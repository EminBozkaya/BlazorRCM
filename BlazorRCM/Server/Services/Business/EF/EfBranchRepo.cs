using AutoMapper;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfBranchRepo : EfRepositoryBase<RCMBlazorContext, Branch, BranchDTO>, IBranchRepo

    {
        public EfBranchRepo(IMapper Mapper) : base(Mapper)
        {
        }
    }
}

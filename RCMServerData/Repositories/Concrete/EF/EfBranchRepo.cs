using AutoMapper;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;

namespace RCMServerData.Repositories.Concrete.EF
{
    public class EfBranchRepo : EfRepositoryBase<RCMBlazorContext, Branch, BranchDTO>, IBranchRepo

    {
        public EfBranchRepo(IMapper Mapper) : base(Mapper)
        {
        }
    }
}

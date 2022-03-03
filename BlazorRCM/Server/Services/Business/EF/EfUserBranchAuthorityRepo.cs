using AutoMapper;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfUserBranchAuthorityRepo : EfRepositoryBase<RCMBlazorContext, UserBranchAuthority, UserBranchAuthorityDTO>, IUserBranchAuthorityRepo

    {
        public EfUserBranchAuthorityRepo(IMapper Mapper) : base(Mapper)
        {
        }
    }
}

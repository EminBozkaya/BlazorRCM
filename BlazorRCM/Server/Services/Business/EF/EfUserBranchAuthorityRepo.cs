using AutoMapper;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfUserBranchAuthorityRepo : EfRepositoryBase<RCMBlazorContext, UserBranchAuthority, UserBranchAuthorityDTO>, IUserBranchAuthorityRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfUserBranchAuthorityRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

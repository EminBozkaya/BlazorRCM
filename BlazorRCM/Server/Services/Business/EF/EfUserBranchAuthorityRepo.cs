using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Server.Services.BaseServices.BaseService.EF;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<UserBranchAuthorityDTO>> MyList()
        {
            using RCMBlazorContext ctx = new();
            var query = ctx.Set<UserBranchAuthority>().AsQueryable();

                var list = await query
                      .ProjectTo<UserBranchAuthorityDTO>(mapper.ConfigurationProvider).ToListAsync();
            return list;
        }





    }
}

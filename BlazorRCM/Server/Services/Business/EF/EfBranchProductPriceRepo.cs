using AutoMapper;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Server.Services.BaseServices.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfBranchProductPriceRepo : EfRepositoryBase<RCMBlazorContext, BranchProductPrice, BranchProductPriceDTO>, IBranchProductPriceRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfBranchProductPriceRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

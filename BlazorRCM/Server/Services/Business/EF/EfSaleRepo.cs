using AutoMapper;
using BlazorRCM.Server.Services.BaseServices.BaseService.EF;
using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfSaleRepo : EfRepositoryBase<RCMBlazorContext, Sale, SaleDTO>, ISaleRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfSaleRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

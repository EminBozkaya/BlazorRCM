using AutoMapper;
using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Server.Services.BaseServices.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfSupplierRepo : EfRepositoryBase<RCMBlazorContext, Supplier, SupplierDTO>, ISupplierRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfSupplierRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

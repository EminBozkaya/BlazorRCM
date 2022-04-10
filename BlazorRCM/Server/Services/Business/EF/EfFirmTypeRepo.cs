using AutoMapper;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Server.Services.BaseServices.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfFirmTypeRepo : EfRepositoryBase<RCMBlazorContext, FirmType, FirmTypeDTO>, IFirmTypeRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfFirmTypeRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

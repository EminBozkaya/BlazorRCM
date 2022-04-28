using AutoMapper;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Server.Services.BaseServices.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfProductSaleNoteRepo : EfRepositoryBase<RCMBlazorContext, ProductSaleNote, ProductSaleNoteDTO>, IProductSaleNoteRepo

    {
        private IConfiguration configuration;
        private IMapper mapper;
        public EfProductSaleNoteRepo(IMapper Mapper, IConfiguration Configuration) : base(Mapper, Configuration)
        {
            configuration = Configuration;
            mapper = Mapper;
        }
    }
}

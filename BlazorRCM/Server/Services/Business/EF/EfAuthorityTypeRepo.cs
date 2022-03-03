using AutoMapper;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfAuthorityTypeRepo : EfRepositoryBase<RCMBlazorContext, AuthorityType, AuthorityTypeDTO>, IAuthorityTypeRepo

    {
        public EfAuthorityTypeRepo(IMapper Mapper) : base(Mapper)
        {
        }
    }
}

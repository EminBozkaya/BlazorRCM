using AutoMapper;
using BlazorRCM.Shared.DTOs;
using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;

namespace BlazorRCM.Server.Services.Business.EF
{
    public class EfUserRepo : EfRepositoryBase<RCMBlazorContext, User, UserDTO>, IUserRepo
    {
        
        public EfUserRepo(IMapper Mapper) : base(Mapper)
        {
        }

        //public List<User> GetByAuthorityTypeId(byte ATId)
        //{
        //    return
        //        base.GetAll(x => x.UserBranchAuthorities
        //            .Select(y => y.ATId)
        //            .Contains(ATId))
        //            .ToList();
        //}
    }
}

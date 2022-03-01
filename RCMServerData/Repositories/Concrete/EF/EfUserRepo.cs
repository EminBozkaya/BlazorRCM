using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace RCMServerData.Repositories.Concrete.EF
{
    public class EfUserRepo : EfRepositoryBase<RCMBlazorContext, User>, IUserRepo
    {
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

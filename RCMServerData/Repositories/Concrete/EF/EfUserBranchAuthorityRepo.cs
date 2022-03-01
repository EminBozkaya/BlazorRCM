using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;

namespace RCMServerData.Repositories.Concrete.EF
{
    public class EfUserBranchAuthorityRepo : EfRepositoryBase<RCMBlazorContext, UserBranchAuthority>, IUserBranchAuthorityRepo

    {
    }
}

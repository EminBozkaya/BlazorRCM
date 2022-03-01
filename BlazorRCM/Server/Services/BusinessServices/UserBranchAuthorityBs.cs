using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class UserBranchAuthorityBs : BusinessService<UserBranchAuthority>
    {
        private readonly IUserBranchAuthorityRepo _repo;


        public UserBranchAuthorityBs(IUserBranchAuthorityRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;
using BlazorRCM.Shared.DTOs;

namespace RCM.Business.Concrete
{
    public class UserBranchAuthorityBs : BusinessService<UserBranchAuthorityDTO>
    {
        private readonly IUserBranchAuthorityRepo _repo;


        public UserBranchAuthorityBs(IUserBranchAuthorityRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

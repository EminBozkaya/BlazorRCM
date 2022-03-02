using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;
using BlazorRCM.Shared.DTOs;

namespace RCM.Business.Concrete
{
    public class BranchBs : BusinessService<BranchDTO>
    {
        private readonly IBranchRepo _repo;


        public BranchBs(IBranchRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

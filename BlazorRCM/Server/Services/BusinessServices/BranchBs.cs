using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchBs : BusinessService<Branch>
    {
        private readonly IBranchRepo _repo;


        public BranchBs(IBranchRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

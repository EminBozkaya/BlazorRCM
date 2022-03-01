using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchCaseTypeBs : BusinessService<BranchCaseType>
    {
        private readonly IBranchCaseTypeRepo _repo;

               
        public BranchCaseTypeBs(IBranchCaseTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

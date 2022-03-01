using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchCaseTypeFlowBs : BusinessService<BranchCaseTypeFlow>
    {
        private readonly IBranchCaseTypeFlowRepo _repo;

               
        public BranchCaseTypeFlowBs(IBranchCaseTypeFlowRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchConsumptionBs : BusinessService<BranchConsumption>
    {
        private readonly IBranchConsumptionRepo _repo;

               
        public BranchConsumptionBs(IBranchConsumptionRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchRevenueDistributionBs : BusinessService<BranchRevenueDistribution>
    {
        private readonly IBranchRevenueDistributionRepo _repo;


        public BranchRevenueDistributionBs(IBranchRevenueDistributionRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

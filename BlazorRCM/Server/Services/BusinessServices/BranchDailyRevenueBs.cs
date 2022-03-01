using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchDailyRevenueBs : BusinessService<BranchDailyRevenue>
    {
        private readonly IBranchDailyRevenueRepo _repo;


        public BranchDailyRevenueBs(IBranchDailyRevenueRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

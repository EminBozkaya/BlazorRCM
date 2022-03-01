using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchStockBs : BusinessService<BranchStock>
    {
        private readonly IBranchStockRepo _repo;


        public BranchStockBs(IBranchStockRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

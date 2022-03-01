using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchStockEntryBs : BusinessService<BranchStockEntry>
    {
        private readonly IBranchStockEntryRepo _repo;


        public BranchStockEntryBs(IBranchStockEntryRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

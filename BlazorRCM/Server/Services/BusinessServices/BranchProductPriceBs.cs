using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchProductPriceBs : BusinessService<BranchProductPrice>
    {
        private readonly IBranchProductPriceRepo _repo;


        public BranchProductPriceBs(IBranchProductPriceRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

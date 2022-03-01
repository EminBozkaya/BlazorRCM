using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchCreditCardBs : BusinessService<BranchCreditCard>
    {
        private readonly IBranchCreditCardRepo _repo;


        public BranchCreditCardBs(IBranchCreditCardRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

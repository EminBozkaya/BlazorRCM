using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class BranchCreditCardFlowBs : BusinessService<BranchCreditCardFlow>
    {
        private readonly IBranchCreditCardFlowRepo _repo;


        public BranchCreditCardFlowBs(IBranchCreditCardFlowRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

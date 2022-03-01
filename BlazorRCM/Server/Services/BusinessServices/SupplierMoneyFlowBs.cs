using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SupplierMoneyFlowBs : BusinessService<SupplierMoneyFlow>
    {
        private readonly ISupplierMoneyFlowRepo _repo;


        public SupplierMoneyFlowBs(ISupplierMoneyFlowRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

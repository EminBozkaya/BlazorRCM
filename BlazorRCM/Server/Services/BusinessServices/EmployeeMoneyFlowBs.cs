using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class EmployeeMoneyFlowBs : BusinessService<EmployeeMoneyFlow>
    {
        private readonly IEmployeeMoneyFlowRepo _repo;


        public EmployeeMoneyFlowBs(IEmployeeMoneyFlowRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

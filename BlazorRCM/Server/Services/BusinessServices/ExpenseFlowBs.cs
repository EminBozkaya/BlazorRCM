using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class ExpenseFlowBs : BusinessService<ExpenseFlow>
    {
        private readonly IExpenseFlowRepo _repo;


        public ExpenseFlowBs(IExpenseFlowRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class ExpenseTypeBs : BusinessService<ExpenseType>
    {
        private readonly IExpenseTypeRepo _repo;


        public ExpenseTypeBs(IExpenseTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

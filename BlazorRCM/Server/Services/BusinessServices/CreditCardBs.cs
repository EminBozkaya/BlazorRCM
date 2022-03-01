using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class CreditCardBs : BusinessService<CreditCard>
    {
        private readonly ICreditCardRepo _repo;


        public CreditCardBs(ICreditCardRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

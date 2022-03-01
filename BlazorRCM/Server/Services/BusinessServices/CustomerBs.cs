using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class CustomerBs : BusinessService<Customer>
    {
        private readonly ICustomerRepo _repo;


        public CustomerBs(ICustomerRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

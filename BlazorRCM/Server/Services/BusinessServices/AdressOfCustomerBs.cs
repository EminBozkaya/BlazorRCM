using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class AdressOfCustomerBs : BusinessService<AdressOfCustomer>
    {
        private readonly IAdressOfCustomerRepo _repo;

               
        public AdressOfCustomerBs(IAdressOfCustomerRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

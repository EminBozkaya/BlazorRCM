using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SupplierBs : BusinessService<Supplier>
    {
        private readonly ISupplierRepo _repo;


        public SupplierBs(ISupplierRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

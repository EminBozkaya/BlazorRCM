using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class RawMaterialOfSupplierBs : BusinessService<RawMaterialOfSupplier>
    {
        private readonly IRawMaterialOfSupplierRepo _repo;


        public RawMaterialOfSupplierBs(IRawMaterialOfSupplierRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class RawMaterialOfProductBs : BusinessService<RawMaterialOfProduct>
    {
        private readonly IRawMaterialOfProductRepo _repo;


        public RawMaterialOfProductBs(IRawMaterialOfProductRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

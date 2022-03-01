using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class RawMaterialBs : BusinessService<RawMaterial>
    {
        private readonly IRawMaterialRepo _repo;


        public RawMaterialBs(IRawMaterialRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

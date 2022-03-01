using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class RollCallTypeBs : BusinessService<RollCallType>
    {
        private readonly IRollCallTypeRepo _repo;


        public RollCallTypeBs(IRollCallTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

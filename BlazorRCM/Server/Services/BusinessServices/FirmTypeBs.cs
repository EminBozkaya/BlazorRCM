using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class FirmTypeBs : BusinessService<FirmType>
    {
        private readonly IFirmTypeRepo _repo;


        public FirmTypeBs(IFirmTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

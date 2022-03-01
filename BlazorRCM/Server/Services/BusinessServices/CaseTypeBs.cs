using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class CaseTypeBs : BusinessService<CaseType>
    {
        private readonly ICaseTypeRepo _repo;


        public CaseTypeBs(ICaseTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class ConsumeTypeBs : BusinessService<ConsumeType>
    {
        private readonly IConsumeTypeRepo _repo;


        public ConsumeTypeBs(IConsumeTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

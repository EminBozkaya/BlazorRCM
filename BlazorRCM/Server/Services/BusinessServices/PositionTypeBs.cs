using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class PositionTypeBs : BusinessService<PositionType>
    {
        private readonly IPositionTypeRepo _repo;


        public PositionTypeBs(IPositionTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

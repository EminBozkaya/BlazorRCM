using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SaleTypeBs : BusinessService<SaleType>
    {
        private readonly ISaleTypeRepo _repo;


        public SaleTypeBs(ISaleTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

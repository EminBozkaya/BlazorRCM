using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SaleDetailBs : BusinessService<SaleDetail>
    {
        private readonly ISaleDetailRepo _repo;


        public SaleDetailBs(ISaleDetailRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

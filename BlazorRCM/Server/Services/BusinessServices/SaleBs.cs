using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SaleBs : BusinessService<Sale>
    {
        private readonly ISaleRepo _repo;


        public SaleBs(ISaleRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

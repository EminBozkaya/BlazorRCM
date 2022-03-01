using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SalaryTypeBs : BusinessService<SalaryType>
    {
        private readonly ISalaryTypeRepo _repo;


        public SalaryTypeBs(ISalaryTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

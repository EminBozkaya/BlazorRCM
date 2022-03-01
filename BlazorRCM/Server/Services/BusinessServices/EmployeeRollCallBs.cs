using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class EmployeeRollCallBs : BusinessService<EmployeeRollCall>
    {
        private readonly IEmployeeRollCallRepo _repo;


        public EmployeeRollCallBs(IEmployeeRollCallRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

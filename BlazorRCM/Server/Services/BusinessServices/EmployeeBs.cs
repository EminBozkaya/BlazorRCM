using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class EmployeeBs : BusinessService<Employee>
    {
        private readonly IEmployeeRepo _repo;


        public EmployeeBs(IEmployeeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

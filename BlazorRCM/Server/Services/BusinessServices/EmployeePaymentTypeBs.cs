using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class EmployeePaymentTypeBs : BusinessService<EmployeePaymentType>
    {
        private readonly IEmployeePaymentTypeRepo _repo;


        public EmployeePaymentTypeBs(IEmployeePaymentTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

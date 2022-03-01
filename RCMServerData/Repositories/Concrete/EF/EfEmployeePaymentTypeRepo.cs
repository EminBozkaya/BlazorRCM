using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;

namespace RCMServerData.Repositories.Concrete.EF
{
    public class EfEmployeePaymentTypeRepo : EfRepositoryBase<RCMBlazorContext, EmployeePaymentType>, IEmployeePaymentTypeRepo

    {
    }
}

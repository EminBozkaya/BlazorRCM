using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;

namespace RCMServerData.Repositories.Concrete.EF
{
    public class EfCustomerRepo : EfRepositoryBase<RCMBlazorContext, Customer>, ICustomerRepo

    {
    }
}

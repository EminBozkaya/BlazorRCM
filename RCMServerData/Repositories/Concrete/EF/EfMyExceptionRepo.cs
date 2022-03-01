using Core.BaseService.EF;
using RCMServerData.EFContext;
using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMServerData.Repositories.Concrete.EF
{
    public class EfMyExceptionRepo: EfRepositoryBase<RCMBlazorContext, MyException>, IMyExceptionRepo
    {
    }
}

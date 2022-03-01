using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class MyExceptionBs : BusinessService<MyException>
    {
        private readonly IMyExceptionRepo _repo;
        public MyExceptionBs(IMyExceptionRepo repo)
            : base(repo)
        {
            _repo = repo;
        }

    }
}

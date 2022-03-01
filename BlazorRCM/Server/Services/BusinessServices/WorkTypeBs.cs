using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class WorkTypeBs : BusinessService<WorkType>
    {
        private readonly IWorkTypeRepo _repo;


        public WorkTypeBs(IWorkTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

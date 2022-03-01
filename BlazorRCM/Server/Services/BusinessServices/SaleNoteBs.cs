using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SaleNoteBs : BusinessService<SaleNote>
    {
        private readonly ISaleNoteRepo _repo;


        public SaleNoteBs(ISaleNoteRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

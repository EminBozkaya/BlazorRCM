using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;


namespace RCM.Business.Concrete
{
    public class SaleNoteCategoryBs : BusinessService<SaleNoteCategory>
    {
        private readonly ISaleNoteCategoryRepo _repo;
        public SaleNoteCategoryBs(ISaleNoteCategoryRepo repo) : base(repo)
        {
            _repo = repo;
        }
    }
}

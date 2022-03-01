using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class SaleNoteOfProductBs : BusinessService<SaleNoteOfProduct>
    {
        private readonly ISaleNoteOfProductRepo _repo;


        public SaleNoteOfProductBs(ISaleNoteOfProductRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

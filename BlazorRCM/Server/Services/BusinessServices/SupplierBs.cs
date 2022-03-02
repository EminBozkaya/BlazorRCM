using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;
using BlazorRCM.Shared.DTOs;

namespace RCM.Business.Concrete
{
    public class SupplierBs : BusinessService<SupplierDTO>
    {
        private readonly ISupplierRepo _repo;


        public SupplierBs(ISupplierRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

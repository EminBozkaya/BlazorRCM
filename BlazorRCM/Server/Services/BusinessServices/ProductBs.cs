using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class ProductBs : BusinessService<Product>
    {
        private readonly IProductRepo _repo;


        public ProductBs(IProductRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

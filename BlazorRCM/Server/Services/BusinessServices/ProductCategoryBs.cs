using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class ProductCategoryBs : BusinessService<ProductCategory>
    {
        private readonly IProductCategoryRepo _repo;


        public ProductCategoryBs(IProductCategoryRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

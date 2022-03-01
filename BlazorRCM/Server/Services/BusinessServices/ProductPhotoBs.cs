using RCMServerData.Repositories.Abstract;
using RCMServerData.Models;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class ProductPhotoBs : BusinessService<ProductPhoto>
    {
        private readonly IProductPhotoRepo _repo;


        public ProductPhotoBs(IProductPhotoRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

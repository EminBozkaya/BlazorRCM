using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using BlazorRCM.Server.Services.BusinessInfrastructure;

namespace RCM.Business.Concrete
{
    public class AuthorityTypeBs : BusinessService<AuthorityType>
    {
        private readonly IAuthorityTypeRepo _repo;

               
        public AuthorityTypeBs(IAuthorityTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

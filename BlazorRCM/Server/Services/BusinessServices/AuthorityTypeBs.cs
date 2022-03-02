using RCMServerData.Models;
using RCMServerData.Repositories.Abstract;
using BlazorRCM.Server.Services.BusinessInfrastructure;
using BlazorRCM.Shared.DTOs;

namespace RCM.Business.Concrete
{
    public class AuthorityTypeBs : BusinessService<AuthorityTypeDTO>
    {
        private readonly IAuthorityTypeRepo _repo;

               
        public AuthorityTypeBs(IAuthorityTypeRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}

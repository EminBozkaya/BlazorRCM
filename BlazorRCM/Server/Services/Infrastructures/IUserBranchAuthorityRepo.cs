using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Server.Services.BaseServices.BaseInfrastructure;

namespace BlazorRCM.Server.Services.Infrastructures
{
    public interface IUserBranchAuthorityRepo : IRepository<UserBranchAuthorityDTO>
    {
        public Task<List<UserBranchAuthorityDTO>> MyList();
    }
}

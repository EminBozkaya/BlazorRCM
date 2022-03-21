using BlazorRCM.Shared.DTOs;
using Core.BaseInfrastructure;
using RCMServerData.Models;

namespace BlazorRCM.Server.Infrasructures
{
    public interface IUserBranchAuthorityRepo : IRepository<UserBranchAuthorityDTO>
    {
    }
}

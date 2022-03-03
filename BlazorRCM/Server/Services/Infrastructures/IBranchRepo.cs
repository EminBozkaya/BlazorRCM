using BlazorRCM.Shared.DTOs;
using Core.BaseInfrastructure;
using RCMServerData.Models;

namespace BlazorRCM.Server
{
    public interface IBranchRepo : IRepository<BranchDTO>
    {
    }
}

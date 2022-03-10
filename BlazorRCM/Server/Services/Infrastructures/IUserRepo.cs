using BlazorRCM.Shared.DTOs;
using Core.BaseInfrastructure;
using RCMServerData.Models;

namespace BlazorRCM.Server
{
    public interface IUserRepo : IRepository<UserDTO>
    {
        public Task<UserLoginResponseDTO> Login(string username, string password);
    }
}

using BlazorRCM.Shared.DTOs;
using Core.BaseInfrastructure;
using RCMServerData.Models;

namespace BlazorRCM.Server.Infrasructures
{
    public interface IUserRepo : IRepository<UserDTO>
    {
        public Task<UserLoginResponseDTO> Login(string username, string password);
    }
}

using BlazorRCM.Server.Services.BaseServices.BaseInfrastructure;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.DTOs.ViewDTOs;

namespace BlazorRCM.Server.Infrasructures
{
    public interface IUserRepo : IRepository<UserDTO>
    {
        public Task<UserLoginResponseDTO> Login(string username, string password);
    }
}

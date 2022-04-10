using BlazorRCM.Shared.DTOs.BaseDTOs;
using BlazorRCM.Shared.DTOs.ModelDTOs;

namespace BlazorRCM.Shared.DTOs.ViewDTOs
{
    public class UserLoginResponseDTO : BaseDTO
    {
        public string? ApiToken { get; set; }
        public UserDTO? User { get; set; }
    }
}

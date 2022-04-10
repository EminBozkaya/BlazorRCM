using BlazorRCM.Shared.DTOs.BaseDTOs;

namespace BlazorRCM.Shared.DTOs.ViewDTOs
{
    public class UserLoginRequestDTO: BaseDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}

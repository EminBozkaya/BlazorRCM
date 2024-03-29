﻿using BlazorRCM.Server.Services.BaseServices.BaseInfrastructure;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.DTOs.ViewDTOs;

namespace BlazorRCM.Server.Services.Infrastructures
{
    public interface IUserRepo : IRepository<UserDTO>
    {
        public Task<UserLoginResponseDTO> Login(string username, string password);
    }
}

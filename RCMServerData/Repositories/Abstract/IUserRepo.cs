﻿using BlazorRCM.Shared.DTOs;
using Core.BaseInfrastructure;
using RCMServerData.Models;

namespace RCMServerData.Repositories.Abstract
{
    public interface IUserRepo : IRepository<UserDTO>
    {
    }
}

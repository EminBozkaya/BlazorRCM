﻿using BlazorRCM.Shared.DTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ModelDTOs
{
    public class UserBranchAuthorityDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public int UId { get; set; }
        public short BId { get; set; }
        public short ATId { get; set; }
        //public bool IsActive { get; set; }
        public string? UserFullName { get; set; }
        public string? BranchName { get; set; }
        public string? AuthorityTypeName { get; set; }
    }
}

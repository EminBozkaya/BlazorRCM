using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs
{
    public class UserBranchAuthorityDTO : BaseDTO
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public short BId { get; set; }
        public short ATId { get; set; }
        public bool IsActive { get; set; }
        public string? UserFullName { get; set; }
        public string? BranchName { get; set; }
        public string? AuthorityTypeName { get; set; }
    }
}

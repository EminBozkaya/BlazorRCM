using BlazorRCM.Shared.DTOs.BaseDTOs;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ComplexDTOs
{
    public class AddNewUserDTO : BaseDTO
    {
        public List<UserDTO>? UserDTOList { get; set; }
        public List<BranchDTO>? BranchDTOList { get; set; }
        public List<AuthorityTypeDTO>? AuthorityTypeDTOList { get; set; }
    }
}

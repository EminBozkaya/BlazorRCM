using BlazorRCM.Shared.DTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ModelDTOs
{
    public class FirmTypeDTO : BaseDTO
    {
        public short Id { get; set; }
        public string? Name { get; set; }
    }
}

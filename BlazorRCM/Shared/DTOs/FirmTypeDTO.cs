using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs
{
    public class FirmTypeDTO : BaseDTO
    {
        public short Id { get; set; }
        public string? Name { get; set; }
    }
}

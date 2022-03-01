using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs
{
    public class BranchDTO : BaseDTO
    {
        public short BId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}

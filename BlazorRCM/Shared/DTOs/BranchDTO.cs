using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs
{
    public class BranchDTO : BaseDTO
    {
        public short Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}

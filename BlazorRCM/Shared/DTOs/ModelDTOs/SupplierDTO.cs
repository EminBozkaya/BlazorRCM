using BlazorRCM.Shared.DTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ModelDTOs
{
    public class SupplierDTO : BaseDTO
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsActive { get; set; }
    }
}

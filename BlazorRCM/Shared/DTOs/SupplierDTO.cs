using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs
{
    public class SupplierDTO : BaseDTO
    {
        public int SpId { get; set; }
        public short BId { get; set; }
        public string? Name { get; set; }
        public byte FTId { get; set; }
        public decimal CurrentDept { get; set; }
        public string? Adress { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsActive { get; set; }
    }
}

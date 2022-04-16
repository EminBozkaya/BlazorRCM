using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ViewDTOs
{
    public class QuickSaleBillDTO
    {
        public short LineNo { get; set; }
        public bool HasNote { get; set; }
        public string? ProductName { get; set; }
        public float Portion { get; set; }
        public float ProductPrice { get; set; }
        public short Quantity { get; set; }
        public float TotalPrice { get; set; }
        
    }
}

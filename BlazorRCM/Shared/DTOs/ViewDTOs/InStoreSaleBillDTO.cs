using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ViewDTOs
{
    public class InStoreSaleBillDTO
    {
        //public int LineNo { get; set; }

        public Guid Id { get; set; }
        public bool HasNote { get; set; }
        public string? ProductName { get; set; }
        public decimal Portion { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}

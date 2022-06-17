using Microsoft.EntityFrameworkCore;
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

        public Guid GuId { get; set; }
        public short PId { get; set; }
        public bool HasNote { get; set; }
        public string? ProductName { get; set; }
        public decimal Portion { get; set; }
        public decimal ProductPrice { get; set; }
        public short Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public ProductNoteModalResultDTO? ResultDTO { get; set; }
        
    }
}

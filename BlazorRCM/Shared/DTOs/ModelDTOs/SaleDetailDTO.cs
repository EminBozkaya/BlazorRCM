using BlazorRCM.Shared.DTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ModelDTOs
{
    public class SaleDetailDTO: BaseDTO
    {
        public Guid Id { get; set; }
        public int SId { get; set; }
        public short BillOrder { get; set; }
        public short PId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Portion { get; set; }
        public short Qty { get; set; }
        public decimal Total { get; set; }
        public string? Note { get; set; }
        public string? generalProductNote { get; set; }
        public string? firstProductNote { get; set; }
        public string? secondProductNote { get; set; }
        public string? thirdProductNote { get; set; }
        //public decimal? CutOff { get; set; }
        public bool IsActive { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}

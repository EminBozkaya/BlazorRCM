using BlazorRCM.Shared.DTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ModelDTOs
{
    public class BranchProductPriceDTO : BaseDTO
    {
        public short BId { get; set; }
        public short PId { get; set; }
        public short ColorCode { get; set; }
        public short MenuListId { get; set; }
        public string? ProductName { get; set; }
        public decimal BranchPrice { get; set; }
        public Nullable<bool> IsFavorite { get; set; }
        public bool IsActive { get; set; }
    }
}

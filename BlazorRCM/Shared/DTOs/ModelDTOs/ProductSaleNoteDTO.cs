using BlazorRCM.Shared.DTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ModelDTOs
{
    public class ProductSaleNoteDTO : BaseDTO
    {
        public short Id { get; set; }
        public short NoteCat { get; set; }
        public string? Definition { get; set; }
    }
}

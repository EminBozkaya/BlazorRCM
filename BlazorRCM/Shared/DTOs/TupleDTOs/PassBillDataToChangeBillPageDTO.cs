using BlazorRCM.Shared.DTOs.ViewDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.TupleDTOs
{
    public class PassBillDataToChangeBillPageDTO
    {
        public int SaleID { get; set; }
        public DateTime SaleTime { get; set; }
        public decimal BillTotalPrice { get; set; }
        public List<InStoreSaleBillDTO>? InStoreSaleBillDTOList { get; set; }
    }
}

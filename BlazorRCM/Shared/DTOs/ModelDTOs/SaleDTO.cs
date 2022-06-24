using BlazorRCM.Shared.DTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs.ModelDTOs
{
    public class SaleDTO: BaseDTO
    {
        public int Id { get; set; }
        public int DailyBillOrder { get; set; }
        public short BId { get; set; }
        public short STId { get; set; }
        public DateTime DateTime { get; set; }
        public int UId { get; set; }
        public int ModifiedBy { get; set; }
        public int DeletedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public DateTime DeletedTime { get; set; }
        public bool IsModified { get; set; }
        public string? UserFullName { get; set; }
        public string? ModifierFullName { get; set; }
        public string? DeleterFullName { get; set; }
        //public short? CTId { get; set; }
        //public int? CId { get; set; }
        public decimal TotalPrice { get; set; }
        public string? SaleNote { get; set; }
        //public string? IpAdress { get; set; }
        public bool IsEOD { get; set; }
        public DateTime? EOD { get; set; }
        public bool IsActive { get; set; }

    }
}

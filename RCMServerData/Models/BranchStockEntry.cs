using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchStockEntry : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public int UId { get; set; }
        public short RMId { get; set; }
        public Nullable<double> RMQty { get; set; }
        public string Note { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual User User { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
    }
}

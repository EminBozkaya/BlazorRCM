using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class SaleDetail : BaseDomain
    {
        public long Id { get; set; }

        public int SId { get; set; }
        public short PId { get; set; }
        public decimal Price { get; set; }
        public byte Qty { get; set; }
        public double Portion { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> CutOff { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual User User { get; set; }
    }
}

using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchStock : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public short RMId { get; set; }
        public double RMQty { get; set; }
        public decimal BasePrice { get; set; }
        public byte VATpercent { get; set; }
        public string? Brand { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<bool> IsShowItem { get; set; }
        public bool IsActive { get; set; }
        public string? IpAdress { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual RawMaterial? RawMaterial { get; set; }
        public virtual User? User { get; set; }
    }
}

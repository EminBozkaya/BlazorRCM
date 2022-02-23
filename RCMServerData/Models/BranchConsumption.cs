using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchConsumption : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public int UId { get; set; }
        public byte ConsTId { get; set; }
        public Nullable<int> InputQty { get; set; }
        public Nullable<int> OutputQty { get; set; }
        public string IpAdress { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }
        public bool IsActive { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ConsumeType ConsumeType { get; set; }
        public virtual User User { get; set; }

    }
}

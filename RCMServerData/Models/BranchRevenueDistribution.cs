using RCMServerData.BaseModels;
using System;

namespace RCMServerData.Models
{
    public class BranchRevenueDistribution : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public byte CTId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime Date { get; set; }
        public int UId { get; set; }
        public string? IpAdress { get; set; }
        public bool IsActive { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual CaseType? CaseType { get; set; }
        public virtual User? User { get; set; }
    }
}

using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class ExpenseFlow : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public byte ExId { get; set; }
        public byte CTId { get; set; }
        public decimal Amount { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public bool IsActive { get; set; }
        public string? Note { get; set; }
        public string? IpAdress { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual CaseType? CaseType { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual User? User { get; set; }
        public virtual ExpenseType? ExpenseType { get; set; }
    }
}

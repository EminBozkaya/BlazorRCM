using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchCaseTypeFlow : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public int UId { get; set; }
        public byte CTId { get; set; }
        public Nullable<decimal> Input { get; set; }
        public Nullable<decimal> Output { get; set; }
        public System.DateTime Date { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }
        public string? IpAdress { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual CaseType? CaseType { get; set; }
        public virtual User? User { get; set; }

    }
}

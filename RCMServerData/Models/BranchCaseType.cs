using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchCaseType : BaseDomain
    {
        public short Id { get; set; }
        public short BId { get; set; }
        public byte CTId { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public System.DateTime Date { get; set; }
        public string IpAdress { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual User User { get; set; }

    }
}

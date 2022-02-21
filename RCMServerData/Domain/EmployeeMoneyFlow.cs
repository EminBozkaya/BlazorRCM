using Core.Model;
using System;

namespace RCMServerData.Domain
{
    public class EmployeeMoneyFlow : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public int UId { get; set; }
        public int PaidEId { get; set; }
        public byte EPTId { get; set; }
        public byte CTId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public string IpAdress { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual EmployeePaymentType EmployeePaymentType { get; set; }
    }
}

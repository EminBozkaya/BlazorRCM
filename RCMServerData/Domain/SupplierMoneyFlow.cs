using Core.Model;
using System;

namespace RCMServerData.Domain
{
    public class SupplierMoneyFlow : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public int UId { get; set; }
        public int SpId { get; set; }
        public byte CTId { get; set; }
        public Nullable<decimal> Dept { get; set; }
        public Nullable<decimal> Payment { get; set; }
        public string Note { get; set; }
        public System.DateTime Date { get; set; }
        public string IpAdress { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }
        public bool IsActive { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual User User { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}

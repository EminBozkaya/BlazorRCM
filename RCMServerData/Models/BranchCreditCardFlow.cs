using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchCreditCardFlow : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public byte CCId { get; set; }
        public int UId { get; set; }
        public Nullable<decimal> Dept { get; set; }
        public Nullable<decimal> Payment { get; set; }
        public System.DateTime Date { get; set; }
        public string Note { get; set; }
        public string IpAdress { get; set; }
        public bool IsActive { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual User User { get; set; }
    }
}

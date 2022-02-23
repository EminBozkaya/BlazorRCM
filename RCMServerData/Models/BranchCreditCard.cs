using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchCreditCard : BaseDomain
    {
        public short Id { get; set; }
        public short BId { get; set; }
        public byte CCId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<decimal> CardDept { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public System.DateTime Date { get; set; }
        public string IpAdress { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual User User { get; set; }
    }
}

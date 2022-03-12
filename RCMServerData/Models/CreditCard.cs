using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class CreditCard : BaseDomain
    {
        public CreditCard()
        {
            this.BranchCreditCards = new HashSet<BranchCreditCard>();
            this.BranchCreditCardFlows = new HashSet<BranchCreditCardFlow>();
        }

        public byte CCId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<BranchCreditCard> BranchCreditCards { get; set; }
        public virtual ICollection<BranchCreditCardFlow> BranchCreditCardFlows { get; set; }
    }
}

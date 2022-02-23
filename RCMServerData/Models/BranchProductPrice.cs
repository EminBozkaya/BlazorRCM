using Core.Model;
using System;

namespace RCMServerData.Models
{
    public class BranchProductPrice : BaseDomain
    {
        public short PId { get; set; }
        public short BId { get; set; }
        public decimal BranchPrice { get; set; }
        public Nullable<double> VATpercent { get; set; }
        public Nullable<bool> IsFavorite { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
    }
}

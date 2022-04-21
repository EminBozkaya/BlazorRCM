using RCMServerData.BaseModels;
using System;

namespace RCMServerData.Models
{
    public class BranchProductPrice : BaseDomain
    {
        //public int Id { get; set; }
        public short BId { get; set; }
        public short PId { get; set; }
        public decimal BranchPrice { get; set; }
        public Nullable<decimal> VATpercent { get; set; }
        public Nullable<bool> IsFavorite { get; set; }
        public bool IsActive { get; set; }

        public Branch? Branch { get; set; }
        public Product? Product { get; set; }
    }
}

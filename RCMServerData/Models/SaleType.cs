using RCMServerData.BaseModels;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class SaleType : BaseDomain
    {
        public SaleType()
        {
            this.Sales = new HashSet<Sale>();
            this.SubSaleTypes = new HashSet<SaleType>();
        }

        public short Id { get; set; }
        public string? Type { get; set; }
        public short? TopSTId { get; set; }
        public bool? IsActive { get; set; }


        public ICollection<Sale> Sales { get; set; }
        public SaleType? TopSaleType { get; set; }
        public ICollection<SaleType> SubSaleTypes { get; set; }
    }
}

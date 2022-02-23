using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class SaleType : BaseDomain
    {
        public SaleType()
        {
            this.Sales = new HashSet<Sale>();
            this.SaleType1 = new HashSet<SaleType>();
        }

        public byte STId { get; set; }
        public string Type { get; set; }
        public Nullable<byte> TopSTId { get; set; }
        public Nullable<double> CutOffRate { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<SaleType> SaleType1 { get; set; }
        public virtual SaleType SaleType2 { get; set; }
    }
}

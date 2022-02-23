using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class RawMaterial : BaseDomain
    {
        public RawMaterial()
        {
            this.BranchStocks = new HashSet<BranchStock>();
            this.BranchStockEntries = new HashSet<BranchStockEntry>();
            this.RawMaterialOfProducts = new HashSet<RawMaterialOfProduct>();
            this.RawMaterialOfSuppliers = new HashSet<RawMaterialOfSupplier>();
        }

        public short RMId { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public Nullable<byte> VATpercent { get; set; }

        public virtual ICollection<BranchStock> BranchStocks { get; set; }
        public virtual ICollection<BranchStockEntry> BranchStockEntries { get; set; }
        public virtual ICollection<RawMaterialOfProduct> RawMaterialOfProducts { get; set; }
        public virtual ICollection<RawMaterialOfSupplier> RawMaterialOfSuppliers { get; set; }
    }
}

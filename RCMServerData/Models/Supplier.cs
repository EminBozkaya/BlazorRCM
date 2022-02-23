using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class Supplier : BaseDomain
    {
        public Supplier()
        {
            this.SupplierMoneyFlows = new HashSet<SupplierMoneyFlow>();
            this.RawMaterialOfSuppliers = new HashSet<RawMaterialOfSupplier>();
        }

        public int SpId { get; set; }
        public short BId { get; set; }
        public string Name { get; set; }
        public byte FTId { get; set; }
        public Nullable<decimal> CurrentDept { get; set; }
        public string Adress { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual User User { get; set; }
        public virtual FirmType FirmType { get; set; }
        public virtual ICollection<RawMaterialOfSupplier> RawMaterialOfSuppliers { get; set; }
        public virtual ICollection<SupplierMoneyFlow> SupplierMoneyFlows { get; set; }
    }
}

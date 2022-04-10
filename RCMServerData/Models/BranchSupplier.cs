using RCMServerData.BaseModels;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class BranchSupplier : BaseDomain
    {
        //public Supplier()
        //{
        //    this.SupplierMoneyFlows = new HashSet<SupplierMoneyFlow>();
        //    this.RawMaterialOfSuppliers = new HashSet<RawMaterialOfSupplier>();
        //}

        public int Id { get; set; }
        //public string? Name { get; set; }
        //public byte FTId { get; set; }
        public short BId { get; set; }
        public int SpId { get; set; }

        //public string? Phone { get; set; }
        //public string? Email { get; set; }
        //public string? Adress { get; set; }
        //public string? Note { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActive { get; set; }

        public Supplier? Supplier { get; set; }        
        public Branch? Branch { get; set; }
        public User? User { get; set; }
        //public virtual FirmType? FirmType { get; set; }
        //public virtual ICollection<RawMaterialOfSupplier> RawMaterialOfSuppliers { get; set; }
        //public virtual ICollection<SupplierMoneyFlow> SupplierMoneyFlows { get; set; }
    }
}

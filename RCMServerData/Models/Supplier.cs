﻿using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class Supplier : BaseDomain
    {
        public Supplier()
        {
            this.BranchSuppliers = new HashSet<BranchSupplier>();
            this.SupplierFirmTypes = new HashSet<SupplierFirmType>();
            //    this.SupplierMoneyFlows = new HashSet<SupplierMoneyFlow>();
            //    this.RawMaterialOfSuppliers = new HashSet<RawMaterialOfSupplier>();
        }

        public int SpId { get; set; }
        //public short BId { get; set; }
        //public string? Name { get; set; }
        //public byte FTId { get; set; }
        public string? CompanyName { get; set; }
        //public string? Phone { get; set; }
        //public string? Email { get; set; }
        public string? Adress { get; set; }
        //public string? Note { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsActive { get; set; }

        //public virtual Branch? Branch { get; set; }
        public virtual User? User { get; set; }
        //public virtual FirmType? FirmType { get; set; }
        public virtual ICollection<BranchSupplier> BranchSuppliers { get; set; }
        public virtual ICollection<SupplierFirmType> SupplierFirmTypes { get; set; }
        //public virtual ICollection<RawMaterialOfSupplier> RawMaterialOfSuppliers { get; set; }
        //public virtual ICollection<SupplierMoneyFlow> SupplierMoneyFlows { get; set; }
    }
}

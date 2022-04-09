using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class FirmType : BaseDomain
    {
        public FirmType()
        {
            //this.Suppliers = new HashSet<Supplier>();
            this.SupplierFirmTypes = new HashSet<SupplierFirmType>();
        }

        public short Id { get; set; }
        public string? Name { get; set; }

        //public virtual ICollection<Supplier> Suppliers { get; set; }
        public ICollection<SupplierFirmType> SupplierFirmTypes { get; set; }
    }
}

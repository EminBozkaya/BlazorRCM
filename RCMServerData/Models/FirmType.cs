using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class FirmType : BaseDomain
    {
        public FirmType()
        {
            this.Suppliers = new HashSet<Supplier>();
        }

        public byte FTId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}

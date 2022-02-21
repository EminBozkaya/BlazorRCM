using Core.Model;

namespace RCMServerData.Domain
{
    public class RawMaterialOfSupplier : BaseDomain
    {
        public int SpId { get; set; }
        public short RMId { get; set; }
        public bool IsActive { get; set; }


        public virtual RawMaterial RawMaterial { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
